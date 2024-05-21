using ApplicationLayer;
using DomainLayer.Model;
using JobCandidateWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateWebAPI.Tests.Controllers
{
    public class JobCandidateControllerTests
    {
        private readonly Mock<IJobCandidateServices> _jobCandidateServices;
        public JobCandidateControllerTests()
        {
            _jobCandidateServices = new Mock<IJobCandidateServices>();
        }
        [Fact]
        public async void CreateORUpdateJobCandidateInfo_WhenAddJobCandidateIsNull_ReturnBadRequest()
        {
            // Arrange
            JobCandidate jobCandidate = null;
            JobCandidateController jobCandidateController = new JobCandidateController(_jobCandidateServices.Object);

            // Act
            var result=await jobCandidateController.CreateORUpdateJobCandidateInfo(jobCandidate);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async void CreateORUpdateJobCandidateInfo_WhenAddJobCandidateValidMandatoryFields_ReturnOkRequest()
        {
            // Arrange
            JobCandidate jobCandidate = new JobCandidate()
            {
                Email="alaasamir@gmail.com",
                FName="Alaa",
                LName="Samir",
                Comment="Comment"
            };
            JobCandidateController jobCandidateController = new JobCandidateController(_jobCandidateServices.Object);

            // Act
            var result=await jobCandidateController.CreateORUpdateJobCandidateInfo(jobCandidate);

            // Assert
            Assert.IsType<OkResult>(result);
        }       
    }
}
