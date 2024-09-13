using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        DataClasses1DataContext db = new DataClasses1DataContext("Data Source=DESKTOP-H3FAVBH;Initial Catalog=QLBH;Integrated Security=True;TrustServerCertificate=True");
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetListDanhMuc()
        {
            var x = db.DanhMucs.ToList();
            return Json(new
            {
                data = x,
                name = "anh quan"
            }, JsonRequestBehavior.AllowGet);
        }
    }
   
}