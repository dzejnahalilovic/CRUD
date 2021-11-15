using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdeaTrading.Context;
using IdeaTrading.Models;
using IdeaTrading.ViewModels;

namespace IdeaTrading.Controllers
{
    public class UserController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: User
        public ActionResult Read()
        {
            var u = db.User
                .Select(x => new UserViewModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    City = x.City,
                    DateOfEmployment = x.DateOfEmployment,
                    Position = x.Position,
                    Phone = x.Phone
                })
                .ToList();

            return View(u);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            using (var context = new MyDbContext()) 
            {
                context.User.Add(user); 
                context.SaveChanges(); 
            }
           
            return RedirectToAction("MessageSuccess");
        }

        public ActionResult MessageSuccess()
        {
            return View();
        }
        public ActionResult Edit(int id) 
        {
            using (var context = new MyDbContext())
            {
                var data = context.User.Where(x => x.ID == id).SingleOrDefault();
                return View(data);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, User user)
        {
            using (var context = new MyDbContext())
            {
                var data = context.User.FirstOrDefault(x => x.ID == id); 
                if (data != null) 
                {
                    data.FirstName = user.FirstName;
                    data.LastName = user.LastName;
                    data.Address = user.Address;
                    data.City = user.City;
                    data.DateOfEmployment = user.DateOfEmployment;
                    data.Position = user.Position;
                    data.Phone = user.Phone;
                    context.SaveChanges();
                    return RedirectToAction("MessageSuccess"); 
                }
                else
                    return View();
            }
        }

      
        public ActionResult Delete(int? id)
        {

            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("MessageSuccess");
        }


        public ActionResult CityTemp()
        {
            var u = db.User.GroupBy(s => s.City)
                 .Select(x => new CityViewModel
                 {
                     City = x.Key,
                     Number = x.Select(c => c.City).Count()
                 })
                 .ToList();

            return View(u);
        }
        public ActionResult City()
        {
            return View();
        }

    }
}
