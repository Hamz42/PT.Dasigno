using Microsoft.EntityFrameworkCore;
using PT.Dasigno.BLL.Persistence.Base;
using PT.Dasigno.BLL.Persistence.Repository;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;
using PT.Dasigno.DAL.Context.ContextDasigno;
using PT.Dasigno.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Dasigno.Tests
{
    public class UsersRepositoryIntegrationTests
    {
        private readonly DbContextOptions<dbContextDasigno> _dbContextOptions;

        public UsersRepositoryIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<dbContextDasigno>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void Search_ShouldReturnUsers_WhenCriteriaMatches()
        {
            // Arrange
            using (var context = new dbContextDasigno(_dbContextOptions))
            {
                context.Set<Users>().AddRange(new List<Users>
                {
                    new Users { FirstName = "John", FirstLastName = "Doe" },
                    new Users { FirstName = "Jane", FirstLastName = "Doe" }
                });
                context.SaveChanges();
            }

            using (var context = new dbContextDasigno(_dbContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var usersRepository = new UsersRepository(unitOfWork);

                var request = new SearchUserRequest
                {
                    FirstName = "John",
                    FirstLastName = "Doe",
                    PageNumber = 1,
                    PageSize = 10
                };

                // Act
                var result = usersRepository.Search(request);

                // Assert
                Assert.Single(result);
                Assert.Equal("John", result.First().FirstName);
            }
        }
    }
}
