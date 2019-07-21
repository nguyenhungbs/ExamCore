using Exam.CoreData.Data.Entities;
using Exam.CoreData.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Services.ProductFacade.Implement
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
