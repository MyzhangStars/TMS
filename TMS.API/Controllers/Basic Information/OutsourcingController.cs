using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 外协单位管理
    /// </summary>
    public class OutsourcingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
