using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using teachme.DAL;
using teachme.Repository;
using Newtonsoft.Json;
using teachme.Models;
using System;
using System.Web;

namespace teachme.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult Categories()
        {
            List<Category> allcategories = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }
        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory", cd);

        }
        public ActionResult Course()
        {
            return View(_unitOfWork.GetRepositoryInstance<Course>().GetCourse());
        }
        public ActionResult CategoryEdit(int catId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(catId));
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category tbl)
        {
            _unitOfWork.GetRepositoryInstance<Category>().Update(tbl);
            return RedirectToAction("Categories");

        }
        public ActionResult CourseEdit(int courseId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Course>().GetFirstorDefault(courseId));
        }

        [HttpPost]
        public ActionResult CourseEdit(Course tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/CourseImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.CourseImage = file != null ? pic : tbl.CourseImage;
            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Course>().Update(tbl);
            return RedirectToAction("Course");
            
        }
        public ActionResult CourseAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult CourseAdd(Course tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/CourseImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.CourseImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Course>().Add(tbl);
            return RedirectToAction("Course");
        }
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetProduct());
        }
        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Update(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Add(tbl);
            return RedirectToAction("Product");
        }
         public ActionResult Instructor()
        {
            return View(_unitOfWork.GetRepositoryInstance<Instructor>().GetInstructor());
        }
        public ActionResult InstructorEdit(int instructorId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Instructor>().GetFirstorDefault(instructorId));
        }
        [HttpPost]
        public ActionResult InstructorEdit(Instructor tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/InstructorImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.InstructorImage = file != null ? pic : tbl.InstructorImage;
            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Instructor>().Update(tbl);
            return RedirectToAction("Instructor");
        }
        public ActionResult InstructorAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult InstructorAdd(Instructor tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/InstructorImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.InstructorImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Instructor>().Add(tbl);
            return RedirectToAction("Instructor");
        }
    }
}