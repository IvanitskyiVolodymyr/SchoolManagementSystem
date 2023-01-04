using System.Net;
using Common.Dtos.Tasks;
using Web.Tests.Integration.Setup;
using Web.Tests.Integration.Tests.Base;
using Common.Dtos.StudentTaskAttachment;
using Infrastructure.Data.Repositories;
using Common.Dtos.StudentTask;
using Common.Serializer;
using System.Threading.Tasks;

namespace Web.Tests.Integration.Tests
{
    public class TasksTests : BaseTestService
    {
        private const string controllerRoute = "api/tasks";
        public TasksTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        [Fact]
        public async Task GetTaskWithStatusAndAttachments_WithCorrectId_ShouldReturn()
        {
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            const int studentTaskId = 5; //task status: done and checked
            
            var response = await Client.GetAsync($"{controllerRoute}/{studentTaskId}/tasks-with-attachments");
            var result = await GetResponse<ResponseTaskWithGradeAndAttachmentsDto>(response);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(result.IsDone == true && result.IsChecked == true);
            Assert.NotNull(result.GradeValue);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        public async Task GetTaskWithStatusAndAttachments_WithAnotherStudentTasks_ShouldReturn406(int studentTaskId)
        {
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var response = await Client.GetAsync($"{controllerRoute}/{studentTaskId}/tasks-with-attachments");
            var result = await GetResponse<ResponseTaskWithGradeAndAttachmentsDto>(response);

            Assert.True(response.StatusCode == HttpStatusCode.NotAcceptable);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public async Task GetTaskWithStatusAndAttachments_ByStudentParent_ShouldReturn(int studentTaskId)
        {
            var authUser = await SetupUser(ModelsProvider.GetParentsLoginData().Where( u => u.Email == "parent@gmail.com").First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var response = await Client.GetAsync($"{controllerRoute}/{studentTaskId}/tasks-with-attachments");
            var result = await GetResponse<ResponseTaskWithGradeAndAttachmentsDto>(response);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public async Task GetTaskWithStatusAndAttachments_ByAnotherParent_ShouldReturn406(int studentTaskId)
        {
            var authUser = await SetupUser(ModelsProvider.GetParentsLoginData().Where(u => u.Email == "parent2@gmail.com").First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var response = await Client.GetAsync($"{controllerRoute}/{studentTaskId}/tasks-with-attachments");
            var result = await GetResponse<ResponseTaskWithGradeAndAttachmentsDto>(response);

            Assert.True(response.StatusCode == HttpStatusCode.NotAcceptable);
        }

        [Fact]
        public async Task SubmitStudentTask_With2Attachments_ShouldChangeTaskStatusAndAttachmentsLinks()
        {
            const int studentTaskId = 2; //task status: not done
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var attachmentsLinks = new List<StudentTaskAttachmentDto>()
            {
                new StudentTaskAttachmentDto{ FileUrl = "www.test.file.url"},
                new StudentTaskAttachmentDto{ FileUrl = "www.test2.file.url"}
            }; 

            var response = await Client.PostAsync($"{controllerRoute}/{studentTaskId}/submit", GetStringContent(attachmentsLinks));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var repository = new TaskRepository(DataAccess);
            var studentTask = await repository.GetStudentTaskById(studentTaskId);

            Assert.True(studentTask.IsDone == true);

            StudentTaskAttachmentModel attachmentModel = new StudentTaskAttachmentModel()
            {
                Links = attachmentsLinks.Select(a => new StudentTaskAttachmentDto { FileUrl = a.FileUrl }).ToList()
            };

            string expectedJson = studentTask.AttachmentsLinks;
            string actualJson = JsonSerializer<StudentTaskAttachmentModel>.Serialize(attachmentModel);

            Assert.Equal(studentTask.AttachmentsLinks, actualJson);

            studentTask.IsDone = false;
            await repository.UpdateStudentTask(new UpdateStudentTaskDto
            {
                IsDone = false,
                AttachmentsLinks = null,
                IsChecked = studentTask.IsChecked,
                IsNeededToBeRedone = studentTask.IsNeededToBeRedone,
                StudentId = studentTask.StudentId,
                TaskId = studentTask.TaskId
            });
        }

        [Fact]
        public async Task CancelNotYetCheckedStudentTask_WithCorrectId_ShouldChangeTaskStatus()
        {
            const int studentTaskId = 3; //task status: done and not checked
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var response = await Client.PostAsync($"{controllerRoute}/{studentTaskId}/cancel", null);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var repository = new TaskRepository(DataAccess);
            var studentTask = await repository.GetStudentTaskById(studentTaskId);

            Assert.True(studentTask.IsDone == false);

            studentTask.IsDone = true;
            await repository.UpdateStudentTask(new UpdateStudentTaskDto
            {
                IsDone = false,
                AttachmentsLinks = studentTask.AttachmentsLinks,
                IsChecked = studentTask.IsChecked,
                IsNeededToBeRedone = studentTask.IsNeededToBeRedone,
                StudentId = studentTask.StudentId,
                TaskId = studentTask.TaskId
            });
        }

        [Fact]
        public async Task CancelCheckedStudentTask_WithCorrectId_ShouldThrowException()
        {
            const int studentTaskId = 5; //task status: done and checked
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            var response = await Client.PostAsync($"{controllerRoute}/{studentTaskId}/cancel", null);

            Assert.Equal(HttpStatusCode.NotAcceptable, response.StatusCode);

            var repository = new TaskRepository(DataAccess);
            var studentTask = await repository.GetStudentTaskById(studentTaskId);

            Assert.True(studentTask.IsDone == true);
        }
    }
}
