using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teachme.DAL;
using teachme.Models;
using teachme.Models.Home;

namespace teachme.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        dbteachmeEntities ctx = new dbteachmeEntities();
        public ActionResult Index(string search)
        {

            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search));
        }
        public ActionResult AddToCart(int courseId,string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var course = ctx.Courses.Find(courseId);
                cart.Add(new Item()
                {
                    Courses = course,
                     Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var course = ctx.Courses.Find(courseId);
                cart.Add(new Item()
                {
                    Courses = course,
                     Quantity = 1

                });
                Session["cart"] = cart;
            }
            return Redirect("Courses");
        }
        public ActionResult RemoveFromCart(int courseId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Courses.CourseId == courseId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Courses");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Courses(string search)
        {
            CourseIndexViewModel model = new CourseIndexViewModel();
            return View(model.CreateModel(search));
           
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Instrcutor()
        {
            InstructorIndexViewModel model = new InstructorIndexViewModel();
            return View(model.CreateModel());
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Shop()
        {
            ProductIndexViewModel model = new ProductIndexViewModel();
            return View(model.CreateModel());
        }
        public ActionResult Blogy()
        {
            return View();
        }
        public ActionResult Shopy()
        {
            return View();
        }
        public ActionResult Eventy()
        {
            return View();
        }
        public ActionResult Coursey()
        {
            return View();
        }
        public ActionResult Instructory()
        {
            return View();
        }
      

    }
}