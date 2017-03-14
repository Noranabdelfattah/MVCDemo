using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeebusinesslayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeebusinesslayer.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {

            return View();
        }

        //[HttpPost]                                                       //create btn fn that takes the forms data and insert it in the DB
        //public ActionResult Create(FormCollection formcollection)
        //{
        //    Employee employee = new Employee();

        //        employee.Name = formcollection["Name"];
        //        employee.Gender = formcollection["Gender"];
        //        employee.City = formcollection["City"];
        //        employee.DepartementId = Convert.ToInt32(formcollection["DepartementId"]);

        //    EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //    empBusinessLayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //}

        /// <summary>
        /// Another way to define the fn, By mapping the data using params names that the same
        /// as that declared in the form xml code
        /// </summary>
        /// <param name="formcollection"></param>
        /// <returns></returns>

        //[HttpPost]                                                       
        //public ActionResult Create(string name , string gender , string city , int departementId )
        //{
        //    Employee employee = new Employee();

        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;
        //    employee.DepartementId = departementId;

        //    EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //    empBusinessLayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //}
   
            //[HttpPost]

        //public ActionResult Create(Employee employee) {
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //        empBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

            ///<summary>
            ///
            /// using updateModel Method
            /// </summary>
            /// 
        [HttpPost]
        [ActionName ("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                UpdateModel(employee);
                EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
                empBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]

        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(emp=>emp.EmployeeId==id);
            return View(employee);
        }

        [HttpPost]

        public ActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                UpdateModel(employee);
                EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
                empBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]

        public ActionResult Details(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }





    }
}