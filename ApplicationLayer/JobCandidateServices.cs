using DomainLayer.IRepositories;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class JobCandidateServices : IJobCandidateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobCandidateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateorUpdateJobCandidatesInfo(JobCandidate jobCandidate_param)
        {
            if (jobCandidate_param == null)
            {
                throw new ArgumentNullException(nameof(jobCandidate_param));
            }

            bool IsFound = await _unitOfWork.JobCandidates.IsFound(i=>i.Email==jobCandidate_param.Email);
            if (IsFound)
            { 
                    _unitOfWork.JobCandidates.Update(jobCandidate_param);
            }
            else
            {
                await _unitOfWork.JobCandidates.Add(jobCandidate_param);
            }
            try
            {
                return await _unitOfWork.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException();
            }          
        }
    }
}
