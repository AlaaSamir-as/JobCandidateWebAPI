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

        [HttpPost]
        public async Task<IActionResult> CreateORUpdateJobCandidateInfo(JobCandidate jobCandidate_param)
        {
            if(jobCandidate_param != null)
            {
                await _jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate_param);
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
