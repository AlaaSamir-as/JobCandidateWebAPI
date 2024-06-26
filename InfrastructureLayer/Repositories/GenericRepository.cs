﻿using DomainLayer.IRepositories;
using InfrastructureLayer.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<T> GetByEmail(string email)
        {
            return await _context.Set<T>().FindAsync(email);
        }

        public async Task<bool> IsFound(Expression<Func<T, bool>> expression)
        { 
            return await _context.Set<T>().AnyAsync(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
