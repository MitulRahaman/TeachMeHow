using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teachme.DAL;
using teachme.Repository;

namespace teachme.Models.Home
{
    public class ProductIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Product> ListOfProducts { get; set; }
        public ProductIndexViewModel CreateModel()
            {
            return new ProductIndexViewModel
            {
                ListOfProducts = _unitOfWork.GetRepositoryInstance<Product>().GetAllRecords()
            };
            }
    }
}