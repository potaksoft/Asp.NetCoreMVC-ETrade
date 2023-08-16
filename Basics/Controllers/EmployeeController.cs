using System;
using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController:Controller
    { 
        public IActionResult Index1()
        {
            string message=$"Hello World.{DateTime.Now.ToString()}";
            return View("Index1",message);
        }
        public ViewResult Index2()
        {
            var names=new String[]
            {
                "Ahmet","Mehmet","Vedat"

            };
            return View(names);
        }

        public IActionResult Index3()
        {
            var list=new List<Employee>()
            {
                new Employee(){Id=1,FirstName="Ahmet",LastName="Potak",Age=32},
                new Employee(){Id=2,FirstName="Felat",LastName="Aslan",Age=32},
                new Employee(){Id=3,FirstName="Hişyar",LastName="Aydın",Age=32}

            };
            return View("Index3",list);
        }

    }

}