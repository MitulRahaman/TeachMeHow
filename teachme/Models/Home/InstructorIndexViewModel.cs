using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teachme.DAL;
using teachme.Repository;

namespace teachme.Models.Home
{
    public class InstructorIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Instructor> ListOfInstructor { get; set; }
        public InstructorIndexViewModel CreateModel()
        {
            return new InstructorIndexViewModel
            {
                ListOfInstructor = _unitOfWork.GetRepositoryInstance<Instructor>().GetAllRecords()
            };
        }
    }
}