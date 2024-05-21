using DomainLayer.IRepositories;
using DomainLayer.Model;
using InfrastructureLayer.ApplicationDbContext;
using InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace ApplicationLayer.Tests
{
    public class JobCandidateServicesTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IJobCandidateRepository> _mockJobCandidates;
        public JobCandidateServicesTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockJobCandidates = new Mock<IJobCandidateRepository>();
            _mockUnitOfWork.Setup(u => u.JobCandidates).Returns(_mockJobCandidates.Object);
        }

        [Fact]
        public void CreateORUpdateJobCandidateInfo_WhenAddJobCandidateIsNull_ThrowArgumentNullException()
        {
            // Arrange
            JobCandidate jobCandidate = null;
            JobCandidateServices jobCandidateServices=new JobCandidateServices(_mockUnitOfWork.Object);

            // Act
            Func<JobCandidate, Task> func = (i) => jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate);

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => func(jobCandidate));
        }
        [Fact]
        public async void CreateORUpdateJobCandidateInfo_WhenAddJobCandidateWithValidMandatoryFields_AddJobCandidateInfo()
        {
            // Arrange
            JobCandidate jobCandidate = new JobCandidate()
            {
                Email = "alasamir@gmail.com",
                FName = "Alaa",
                LName = "Samir",
                Comment = "Comment"
            };
            JobCandidateServices jobCandidateServices = new JobCandidateServices(_mockUnitOfWork.Object);

            // Act
            var result = await jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate);

            // Assert
            _mockJobCandidates.Verify(repo=>repo.Add(jobCandidate), Times.Once());
            _mockUnitOfWork.Verify(u=>u.SaveChanges(), Times.Once());

        }
        [Fact]
        public async void CreateORUpdateJobCandidateInfo_WhenAddJobCandidateExistWithValidMandatoryFields_UpdateJobCandidateInfo()
        {
            // Arrange
            JobCandidate jobCandidate = new JobCandidate()
            {
                Email = "alasamir@gmail.com",
                FName = "Alaa",
                LName = "Samir",
                Comment = "Comment"
            };
            JobCandidateServices jobCandidateServices = new JobCandidateServices(_mockUnitOfWork.Object);
            _mockJobCandidates.Setup(repo => repo.IsFound(It.IsAny<Expression<Func<JobCandidate, bool>>>())).ReturnsAsync(true);
            _mockUnitOfWork.Setup(u => u.SaveChanges()).ReturnsAsync(1);

            // Act
            var result = await jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate);

            // Assert
            _mockJobCandidates.Verify(repo=>repo.Update(jobCandidate), Times.Once());
            _mockJobCandidates.Verify(repo=>repo.Add(jobCandidate), Times.Never());
            _mockUnitOfWork.Verify(u=>u.SaveChanges(), Times.Once());
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task CreateorUpdateJobCandidatesInfo_WhenDbUpdateException_ThrowsDbUpdateException()
        {
            // Arrange
            JobCandidate jobCandidate = new JobCandidate()
            {
                Email = "alasamir@gmail.com",
                FName = "Alaa",
                LName = "Samir",
                Comment = "Comment"
            };
            JobCandidateServices jobCandidateServices = new JobCandidateServices(_mockUnitOfWork.Object);
            _mockJobCandidates.Setup(repo => repo.IsFound(It.IsAny<Expression<Func<JobCandidate, bool>>>())).ReturnsAsync(false);
            _mockUnitOfWork.Setup(u => u.SaveChanges()).ThrowsAsync(new DbUpdateException());

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => jobCandidateServices.CreateorUpdateJobCandidatesInfo(jobCandidate));
        }
    }
}