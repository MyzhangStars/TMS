using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
