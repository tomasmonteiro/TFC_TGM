using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using System.Globalization;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class PeriodoService : ServiceBase, IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;
        private readonly IItemRepository _itemRepository;

        public PeriodoService(IPeriodoRepository periodoRepository, IItemRepository itemRepository, INotificador notificador) : base(notificador)
        {
            _periodoRepository = periodoRepository;
            _itemRepository = itemRepository;
        }


        //Método para criar um período, sem criar Quotas
        public void Add(Periodo periodo)
        {
            try
            {
                if (_periodoRepository.Find(a => a.Cod == periodo.Cod && a.Ano == periodo.Ano && a.Status == true).Count() > 0)
                {
                    Notificar("O Período que pretende registar já existe.");
                    return;
                }
                periodo.Cod = GerarCodigoPeriodo(periodo.DataInicio);
                periodo.Ano = DateTime.Now.Year;
                _periodoRepository.Add(periodo);
            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: " + erro.Message.ToString());
                return;
            }

        }

        //Método para criar um período e criar automaticamente as Quotas deste período para os Sócios ativos
        public void AdicionarPeriodoEItem(Periodo periodo)
        {

            try
            {
                var mesesAno = CalcularMeses(periodo.DataInicio, periodo.DataFim);

                for (int i = 0; i < mesesAno.totalMese; i++)
                {

                    periodo.Cod = GerarCodigoPeriodo(mesesAno.Item1[i].DataInicio);

                    if (_periodoRepository.Find(a => a.Cod == periodo.Cod && a.Ano == periodo.Ano && a.Status == true).Count() > 0)
                    {
                        Notificar("O Período "+periodo.Cod+" já existe.");return;
                    }

                    periodo.Status = true;
                    periodo.DataInicio = mesesAno.Item1[i].DataInicio;
                    periodo.DataFim = mesesAno.Item1[i].DataFim;
                    periodo.UltimoDiaUtil = mesesAno.Item1[i].UltimoDiaUtil;
                    _periodoRepository.AdicionarPeriodoEItem(periodo);
                }
                //_periodoRepository.SaveChanges();

            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: " + erro.Message.ToString());return;
            }
        }

        //Calcular a quantidates de meses entre duas datas e os respectivos nomes
        private static (List<MesAno>, int totalMese) CalcularMeses(DateTime dataInicial, DateTime dataFinal)
        {
            List<MesAno> mesesAno = new List<MesAno>();

            //Definir o formato  de cultura para o nome do mês
            CultureInfo cultura = CultureInfo.CreateSpecificCulture("pt-PT");

            //Calcular nº total de meses
            int totalMeses = 0;

            //Percorer os meses entre as datas
            for (DateTime data = dataInicial; data <= dataFinal; data = data.AddMonths(1))
            {
                totalMeses++;

                //Primeiro dia do mês 
                DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);

                //Último dia do mês 
                int ultimoDia = DateTime.DaysInMonth(data.Year, data.Month);
                DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, ultimoDia);


                MesAno mesAno = new MesAno
                {
                    Ano = data.Year,
                    Mes = data.Month,
                    NomeMes = cultura.DateTimeFormat.GetMonthName(data.Month),
                    DataInicio = primeiroDiaDoMes,
                    DataFim = ultimoDiaDoMes,
                    UltimoDiaUtil = CalcularUltimoDiaUtil(primeiroDiaDoMes)
                };
                mesesAno.Add(mesAno);
            }
            return (mesesAno, totalMeses);
        }

        //Método para calcular o último dia útil do mês
        private static DateTime CalcularUltimoDiaUtil(DateTime data)
        {
            int diasUteisEncontrados = 0;
            DateTime dataAtual = new DateTime(data.Year, data.Month, 1);

            while (diasUteisEncontrados < 10)
            {
                //Verifica se é sábado ou domingo
                if (dataAtual.DayOfWeek != DayOfWeek.Saturday
                    &&
                    dataAtual.DayOfWeek != DayOfWeek.Sunday
                    )
                {
                    diasUteisEncontrados++;
                }
                //Avança para o próximo dia
                dataAtual = dataAtual.AddDays(1);
            }
            //Retorna o décimo dia útil
            return dataAtual.AddDays(-1);
        }


        //Método para gerar o Código do Período
        public string GerarCodigoPeriodo(DateTime dataInicial)
        {
            ////Pegar as três primeiras letras do mês atual
            //string nomeMes = DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);
            ////Pegar os dois últimos dígitos do ano atual
            //string ano = DateTime.Now.ToString("yy");

            ////Retornar a junção do mês e ano
            //return $"{nomeMes}{ano}";

            //Pegar as três primeiras letras do mês atual
            string nomeMes = dataInicial.ToString("MMM", CultureInfo.CurrentCulture).ToUpper();
            //Pegar os dois últimos dígitos do ano atual
            string ano = dataInicial.ToString("yy");

            //Retornar a junção do mês e ano
            return $"{nomeMes}{ano}";
        }


        public Periodo BuscarPorCod(string codigo)
        {
            return _periodoRepository.BuscarPorCod(codigo);
        }

        public IEnumerable<Periodo> BuscarTodos()
        {
            return _periodoRepository.BuscarTodos();
        }

        //Torna o registo invisivel para usuário não Administrador
        public void Eliminar(Guid id)
        {
            var periodo = _periodoRepository.GetById(id);
            if (periodo == null)
            {
                Notificar("O Período que pretende eliminar não existe.");
                return;
            }
            periodo.Status = false;
            Update(periodo);
        }
        //Busca todos os registos existentes (visiveis e invisiveis)
        public IEnumerable<Periodo> GetAll()
        {
            return _periodoRepository.GetAll();
        }
        public Periodo GetById(Guid id)
        {
            return _periodoRepository.GetById(id);
        }
        //Elimina o registo permanentemente
        public void Remove(Periodo periodo)
        {
            var novoPeriodo = _periodoRepository.GetById(periodo.Id);
            if (novoPeriodo == null)
            {
                Notificar("O Periodo que pretende eliminar não existe.");
                return;
            }
            _periodoRepository.Remove(novoPeriodo);
        }
        public void Update(Periodo periodo)
        {
            periodo.DataAtualizacao = DateTime.Now;
            _periodoRepository.Update(periodo);
        }
        public void Dispose()
        {
            _periodoRepository.Dispose();
        }
        public class MesAno
        {
            public int Ano { get; set; }
            public int Mes { get; set; }
            public string NomeMes { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime UltimoDiaUtil { get; set; }
            public DateTime DataFim { get; set; }
        }
    }
}
