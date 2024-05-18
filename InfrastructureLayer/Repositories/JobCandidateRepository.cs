using DomainLayer.IRepositories;
using DomainLayer.Model;
using InfrastructureLayer.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class JobCandidateRepository:GenericRepository<JobCandidate>, IJobCandidateRepository
    {
        public JobCandidateRepository(AppDbContext appDbContext):base(appDbContext) { }
    }
}
