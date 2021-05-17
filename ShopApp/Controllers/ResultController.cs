using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class ResultController : Controller
    {
        [HttpGet]
        public IActionResult UserRegister(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FirstName = registerModel.FirstName;
                return View();
            }
            return View();
            
        }
    }
}
