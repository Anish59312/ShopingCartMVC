using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ShopingCartMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminHome()
        {
            return View();
        }

        public ContentResult EmployeeInfo()
        {
            var employees = new XElement("Employees",
                new XElement("Employee",
                    new XElement("EmpId", "101"),
                    new XElement("EmpName", "John Doe")
                ),
                new XElement("Employee",
                    new XElement("EmpId", "102"),
                    new XElement("EmpName", "Jane Smith")
                ),
                new XElement("Employee",
                    new XElement("EmpId", "103"),
                    new XElement("EmpName", "Michael Johnson")
                )
            );

            var employees_string =  employees?.ToString() ?? "";

            return Content(employees_string, "application/xml");
            ;
        }
    }
}
