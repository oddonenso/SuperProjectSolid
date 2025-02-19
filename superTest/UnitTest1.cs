using Domain;
using Domain.Dto;
using Domain.Querry;
using Moq;
using Service;

namespace superTest
{
    public class UnitTest1
    {
        [Fact]
        public void SuccessSearchById()
        {
           SearchById search = new SearchById();
            int id = 1000;
            search.id = id;
            string password = "testPassword";
            string login = "test";
            string country = "TestCountry";
            var mock = new Mock<IRepository>();
            mock.Setup(row => row.GetById(It.IsAny<int>())).Returns(new Domain.Dto.UserDTO()
            {
                Id = id,
                Login = login,
                Password = password,
                Country = country
            });
            IQueryService<SearchById,UserDTO>query = new GetUserByIdQuery(mock.Object);

            //Act
            var item = query.Execute(search);
            //Assert
            Assert.NotNull(item);
            Assert.Equal(id, item.Id);
            Assert.Equal(login, item.Login);
            Assert.Equal(country, item.Country);
            Assert.Equal(password, item.Password);
            mock.Verify(row=>row.GetById(It.IsAny<int>()));

        }

        [Fact]
        public void SuccessSearchByZero()
        {
            SearchById search = new SearchById();
            int id = 0;
            search.id = id;
            string password = "test";
            string login = "test";
            string country = "TestCountry";
            var mock = new Mock<IRepository>();
            mock.Setup(row => row.GetById(It.IsAny<int>())).Returns(new Domain.Dto.UserDTO()
            {
                Id = id,
                Login = login,
                Password = password,
                Country = country
            });
            IQueryService<SearchById, UserDTO> query = new GetUserByIdQuery(mock.Object);

            //Act
            var item = query.Execute(search);
            //Assert
            Assert.Null(item);
            Assert.Equal(id, item.Id);
            Assert.Equal(login, item.Login);
            Assert.Equal(country, item.Country);
            Assert.Equal(password, item.Password);
            mock.Verify(row => row.GetById(It.IsAny<int>()), Times.Never);

        }
    }
}