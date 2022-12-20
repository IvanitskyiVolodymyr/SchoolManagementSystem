using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Moq;
using Newtonsoft.Json;

namespace Services.Tests.Unit.MockRepositories
{
    public class MockParentRepository : Mock<IParentRepository>
    {
        public void CreateParent(InsertParentDto parentDto, int output)
        {
            Setup(x => x.CreateParent(It.Is<InsertParentDto>(i => JsonConvert.SerializeObject(i) == JsonConvert.SerializeObject(parentDto))))
                .ReturnsAsync(output);
        }
    }
}
