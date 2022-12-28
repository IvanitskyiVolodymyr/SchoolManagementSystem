using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockUserRepository : Mock<IUserRepository>
    {
        public void GetUserById(int userId, User? output)
        {
            Setup(x => x.GetUserById(It.Is<int>(i => i == userId)))
                .ReturnsAsync(output);
        }

        public void GetUserByEmail(string email, User? output)
        {
            Setup(x => x.GetUserByEmail(It.Is<string>(i => i == email)))
                .ReturnsAsync(output);
        }

        public void GetClassIdByUserId(int userId, int output)
        {
            Setup(x => x.GetClassIdByUserId(It.Is<int>(i => i == userId)))
                .ReturnsAsync(output);
        }

        public void UpdateUser(User user, int output)
        {
            Setup(x => x.UpdateUser(It.Is<User>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(user))))
                .ReturnsAsync(output);
        }

        public void GetStudentByUserId(int userId, Student? output)
        {
            Setup(x => x.GetStudentByUserId(It.Is<int>(i => i == userId)))
                .ReturnsAsync(output);
        }

        public void GetTeacherByUserId(int userId, Teacher? output)
        {
            Setup(x => x.GetTeacherByUserId(It.Is<int>(i => i == userId)))
                            .ReturnsAsync(output);
        }

        public void GetParentByUserId(int userId, Parent? output)
        {
            Setup(x => x.GetParentByUserId(It.Is<int>(i => i == userId)))
                            .ReturnsAsync(output);
        }
    }
}
