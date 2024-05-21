using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public interface IJobCandidateServices
    {
        Task<int> CreateorUpdateJobCandidatesInfo(JobCandidate jobCandidate);
    }
}
