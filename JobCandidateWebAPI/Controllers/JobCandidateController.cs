using ApplicationLayer;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateController : ControllerBase
    {
        private readonly IJobCandidateServices _jobCandidateServices;
        public JobCandidateController(IJobCandidateServices jobCandidateServices)
        {
            _jobCandidateServices = jobCandidateServices;
        }

        /// <summary>
        /// Create Job Candidate information or Update it if he is exist
        /// </summary>
        /// <param name="jobCandidate_param"></param>
        /// <returns>OK Result or Bad Request if param is null</returns>
        [HttpPost]
        public async Task<IActionResult> CreateORUpdateJobCandidateInfo(JobCandidate jobCandidate_param)
        {
            if(jobCandidate_param == null)
            {
                return BadRequest();
            }
            await _jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate_param);
            return Ok();
        }
    }
}
