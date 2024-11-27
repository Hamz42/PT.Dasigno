using Microsoft.EntityFrameworkCore;
using Moq;
using PT.Dasigno.BLL.Interfaces.Base;
using PT.Dasigno.BLL.Persistence.Repository;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Dasigno.Tests
{
    public class UsersRepositoryTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly UsersRepository _usersRepository;

        public UsersRepositoryTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _usersRepository = new UsersRepository(_mockUnitOfWork.Object);
        }

        [Fact]
        public void Search_ShouldReturnUsers_WhenCriteriaMatches()
        {
            // Arrange
            var users = new List<Users>
            {
                new Users { FirstName = "John", FirstLastName = "Doe" },
                new Users { FirstName = "Jane", FirstLastName = "Doe" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Users>>();
            mockDbSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            _mockUnitOfWork.Setup(u => u.ContextDasigno.Set<Users>()).Returns(mockDbSet.Object);

            var request = new SearchUserRequest
            {
                FirstName = "John",
                FirstLastName = "Doe",
                PageNumber = 1,
                PageSize = 10
            };

            // Act
            var result = _usersRepository.Search(request);

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result.First().FirstName);
        }
    }
}
