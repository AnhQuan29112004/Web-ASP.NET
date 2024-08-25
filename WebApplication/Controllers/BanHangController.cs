using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
    {
        public class BanHangController : Controller
        {
            // GET: BanHang
            DataClasses1DataContext db = new DataClasses1DataContext("Data Source=DESKTOP-H3FAVBH;Initial Catalog=QLBH;Integrated Security=True;TrustServerCertificate=True");
            public ActionResult Index()
            {
                var x = db.sanphams.ToList();
                return View(x);
            }
            public ActionResult Add()
            {
                
                return View();
            }
            public String Create (FormCollection form)
            {
                string ID = form["ten"];
                string ngay = form["ngaySX"];
                sanpham newobj = new sanpham();

                newobj.ten = ID;
                newobj.ngaySX = ngay;

                db.sanphams.InsertOnSubmit(newobj);
                db.SubmitChanges();

                return "Da them";
            }
            public ActionResult Delete(int id)
            {
                sanpham xoa = db.sanphams.FirstOrDefault(x => x.id == id);
                db.sanphams.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Edit()
            {
                return View();
            }

            public ActionResult PostEdit(int id)
            {
                sanpham product = db.sanphams.FirstOrDefault(p => p.id == id);
                return View(product);
            }
            [HttpPost]
            public ActionResult PostEdit(int id, FormCollection form)
            {   
                 
                sanpham product = db.sanphams.FirstOrDefault(p => p.id == id);
                product.ngaySX = form["ngaySX"];
                product.ten = form["ten"];
                db.SubmitChanges();
                return RedirectToAction("Index");

            }

    }
}
