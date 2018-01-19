using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAgenda.Web.Controllers
{
    public class CalendarDayController : Controller
    {
        // GET: CalendarDay
        public ActionResult Index()
        {
            return View();
        }

        // GET: CalendarDay/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalendarDay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarDay/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarDay/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalendarDay/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarDay/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalendarDay/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
