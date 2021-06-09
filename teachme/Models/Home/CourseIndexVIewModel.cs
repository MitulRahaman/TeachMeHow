using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using teachme.DAL;
using teachme.Repository;

namespace teachme.Models.Home
{
    public class CourseIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbteachmeEntities context = new dbteachmeEntities();

        public IEnumerable<Course> ListOfCourse { get; set; }

        public CourseIndexViewModel CreateModel(string search)
        {

            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IEnumerable<Course> data = context.Database.SqlQuery<Course>("GetBySearch @search", param).ToList();
            return new CourseIndexViewModel
            {
                ListOfCourse = data
            };
        }

    }
}