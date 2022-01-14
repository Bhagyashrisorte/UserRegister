using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegister.Models;

namespace UserRegister.Controllers
{
    public class HomeController : Controller
    {
        Employeecontext db = new Employeecontext();
        
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if(ModelState.IsValid== true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if(a > 0)
                {
                     //ViewBag.InsertMessage = "<script>alert('Data Inserted Sucessfully !')"</script>;
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted Sucessfully !')";
                    TempData["InsertMessage"] = "Data Inserted Sucessfully !";
                    return RedirectToAction("Index");
                }
                else
                {
                   ViewBag.InsertMessage = "<script>alert('Data not Inserted !')";
                }

            }
            return View();

        }
        public ActionResult Edit(int id)
        {
            var row = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated !')</script>";
                    //ModelState.Clear();
                    TempData["UpdateMessage"] = "Data Updated Sucessfully !";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Updated !')</script>";
                }

            }
            
            return View();
        }
        public ActionResult Delete(int id )
        {
            if(id > 0)
            {
                var EmployeeIdrow = db.Employees.Where(model => model.Id == id).FirstOrDefault();
                if(EmployeeIdrow != null)
                {
                    db.Entry(EmployeeIdrow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a > 0)
                    {
                        TempData["DeleteMessage"] = "Data Deleted Sucessfully!";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data  not Sucessfully!')</script>";
                    }
                }

            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var DetailsId = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(DetailsId);
        }


    }
}