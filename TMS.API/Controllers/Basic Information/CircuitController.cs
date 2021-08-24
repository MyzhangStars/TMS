using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 线路管理
    /// </summary>
    public class CircuitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
