using Domain.Entities;
using Domain.Repositories;
using Infastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
