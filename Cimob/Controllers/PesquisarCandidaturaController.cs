using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cimob.Controllers
{
    public class PesquisarCandidaturaController : Controller
    {
        // GET: /PesquisarCandidaturaModel/
      //  public IActionResult Index()
      //  {
            //return View();
          //  return "This is my default action...";
       // }
        public string Index()
        {
            return "This is my default action...";
        }
        // 
        // GET: /PesquisarCandidaturaModel/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
