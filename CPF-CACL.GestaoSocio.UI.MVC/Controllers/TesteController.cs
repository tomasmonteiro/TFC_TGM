﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class TesteController : Controller
    {
        // GET: TesteController
        public ActionResult Index()
        {
            var a = "a";
            if (a == "a")
            {
                ViewBag.MensagemSucesso = "Operação sucesso";
                return View();
            }
            else
            {
                ViewBag.MensagemSucesso = "Operação erro";
                return View();
            }
        }

        // GET: TesteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TesteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TesteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TesteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TesteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
