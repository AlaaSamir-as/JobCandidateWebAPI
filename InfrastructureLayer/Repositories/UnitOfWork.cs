﻿using DomainLayer.IRepositories;
using InfrastructureLayer.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IJobCandidateRepository JobCandidates {  get;}
        public UnitOfWork(AppDbContext appDbContext,IJobCandidateRepository jobCandidateRepository)
        {
            _context = appDbContext;
            JobCandidates = jobCandidateRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
