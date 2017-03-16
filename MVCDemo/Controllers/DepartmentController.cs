using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            DepartmentBusinessLayer departementBusinessLayer = new DepartmentBusinessLayer();

            List<Departments> departments = departementBusinessLayer.Departments.ToList();

            return View(departments);
        }
    }
}