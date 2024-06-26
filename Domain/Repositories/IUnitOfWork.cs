﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<int> SaveChangesAsync();

    }
}
