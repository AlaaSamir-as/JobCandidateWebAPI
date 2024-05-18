using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.IRepositories
{
    public interface IUnitOfWork :IDisposable
    {
        IJobCandidateRepository JobCandidates { get; }
        Task<int> SaveChanges();
    }
}
