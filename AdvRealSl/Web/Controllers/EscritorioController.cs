﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EscritorioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}