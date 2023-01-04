using Common.Dtos.Schedule;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using Web.Tests.Integration.Setup;
using Web.Tests.Integration.Tests.Base;

namespace Web.Tests.Integration.Tests
{
    public class SchedulesTests : BaseTestService
    {
        private const string controllerRoute = "api/schedule";
        public SchedulesTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetScheduleForStudentWithAttendancesByPeriod_WhenValidRequest_ShouldReturnSchedules()
        {
            var authUser = await SetupUser(ModelsProvider.GetStudentsLoginData().First());
            AddAuthorizationHeader(authUser.Tokens.AccessToken);

            DateTime startTime = new DateTime(2023, 1, 1);
            DateTime endTime = new DateTime(2023, 2, 1);
            var query = new Dictionary<string, string>()
            {
                ["startDateTime"] = startTime.ToString(),
                ["endDateTime"] = endTime.ToString(),
                ["studentId"] = "3"
            };

            var uri = QueryHelpers.AddQueryString($"{controllerRoute}/students/schedules-with-attendances", query);

            var response = await Client.GetAsync(uri);
            var result = await GetResponse<IEnumerable<ScheduleAttendanceDto>>(response);

            Assert.True(result.Count() > 0);

            foreach(var schedule in result)
            {
                Assert.True(schedule.StartTime > startTime && schedule.EndTime < endTime);
            }

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetScheduleForStudentWithAttendancesByPeriod_WhenUnAuthorizedRequest_ShouldReturn401()
        {
            Client.DefaultRequestHeaders.Authorization = null;

            DateTime startTime = new DateTime(2023, 1, 1);
            DateTime endTime = new DateTime(2023, 2, 1);
            var query = new Dictionary<string, string>()
            {
                ["startDateTime"] = startTime.ToString(),
                ["endDateTime"] = endTime.ToString(),
                ["studentId"] = "3"
            };

            var uri = QueryHelpers.AddQueryString($"{controllerRoute}/students/schedules-with-attendances", query);

            var response = await Client.GetAsync(uri);

            Assert.True(response.StatusCode == HttpStatusCode.Unauthorized);
        }
    }
}
