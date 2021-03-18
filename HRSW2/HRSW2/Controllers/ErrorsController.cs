using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSW2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSW2.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            Errors errorModel = new Errors("Undefined Error");
            return View(errorModel);
        }

        public IActionResult Delete()
        {
            Errors errorModel = new Errors("Delete Failed");
            return View(errorModel);
        }

        public IActionResult Update()
        {
            Errors errorModel = new Errors("Update Failed");
            return View(errorModel);
        }
        public IActionResult Edit()
        {
            Errors errorModel = new Errors("Edit Failed");
            return View(errorModel);
        }
    }
}
