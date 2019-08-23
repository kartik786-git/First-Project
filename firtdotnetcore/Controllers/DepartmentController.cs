using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firtdotnetcore.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: /<controller>/
        public string List()
        {
            return "this is department controller of list() method";
            //return View();

        }

        public string Details()
        {
            return "this is department controller of Details() method";
        }
    }
}
