﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    public class CelestialObjectController : Controller
    {
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        RouteAttribute Route = new RouteAttribute("");
        ApiControllerAttribute ApiController = new ApiControllerAttribute();

        private readonly ApplicationDbContext _context;





        public IActionResult Index()
        {
            return View();
        }
    }
}
