﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByEmail(string email);
        Task Add(T entity);
        void Update(T entity);
    }
}
