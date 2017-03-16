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
        public ActionResult Index(int DepartmentId)
        {
            EmployeeBusinessLayer employeebusinesslayer = new EmployeeBusinessLayer();
            if (DepartmentId == 0)
            {
                List<Employee> employees = employeebusinesslayer.Employees.ToList();

                return View(employees);
            }

            else
            {
                List<Employee> employees = employeebusinesslayer.Employees.Where(emp => emp.DepartementId == DepartmentId).ToList();
                return View(employees);
            }
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

        [HttpPost]

        public ActionResult Create(Employee employee)  //
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
                empBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index", new { @DepartmentId = 0 });
            }

            return View();
        }

        ///<summary>
        ///
        /// using updateModel Method
        /// </summary>
        /// 
        //[HttpPost]
        //[ActionName("Create")]                                               //btdy exception f el validation
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee();
        //        UpdateModel(employee);

        //        EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //        empBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}


        [HttpGet]

        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }

        //[HttpPost]

        //public ActionResult Edit()                                  //allow progs like fiddler to change the data in the 
        //                                                             //DB by sending it in the post url, So it is not secure         
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee();
        //        UpdateModel(employee);
        //        EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //        empBusinessLayer.SaveEmployee(employee);

        //        return RedirectToAction("Index", new { @DepartmentId = 0 });
        //    }

        //    return View();
        //}

        [HttpPost]
        [ActionName("Edit")]
     
        //public ActionResult Edit_post(int id)                                  //Prevent progs like fiddler to change the data in the 
        //                                                                       //DB by sending it in the post url, So it is not secure         
        //{
        //    EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = empBusinessLayer.Employees.Single(x => x.EmployeeId == id);
        //    UpdateModel(employee, new string[] { "EmployeeId", "Gender", "City", "DepartmentId" });// the string contains only the Attributes i allow to be changed ,

        //    //called black list and white list / Include Property or Exclude Property
        //    //OR 
        //    //  UpdateModel(employee,null,null, new string[] { "Name" }); //using the overloaded version of updateModel with the excluding property

        //    if (ModelState.IsValid)
        //    {

        //        empBusinessLayer.SaveEmployee(employee);

        //        return RedirectToAction("Index", new { @DepartmentId = 0 });
        //    }

        //    return View(employee);
        //}
        
            //Include and exclude properities from model binding using bind atttribute
        public ActionResult Edit_post([Bind(Include = "EmployeeId, Gender, City, DepartmentId")]Employee employee)                            
        {
            //OR :
            //   public ActionResult Edit_post([Bind(Exclude = "Name")]Employee employee) {

                EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
          employee.Name = empBusinessLayer.Employees.Single(x => x.EmployeeId == employee.EmployeeId).Name; //we need to reomve the required attribute above Name field in Employee.Cs
 
            if (ModelState.IsValid)
            {

                empBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index", new { @DepartmentId = 0 });
            }

            return View(employee);
        }

        [HttpGet]

        public ActionResult Details(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = empBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
            empBusinessLayer.DeleteEmployee(id);

            return RedirectToAction("Index", new { @DepartmentId = 0 });
        }



    }
}