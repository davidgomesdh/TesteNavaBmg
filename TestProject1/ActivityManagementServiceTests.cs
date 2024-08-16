using Moq;
using TesteNavaBmg.Interfaces;
using TesteNavaBmg.Models;
using TesteNavaBmg.Services;

namespace TestProject1
{
    public class ActivityManagementServiceTests
    {
        [Fact]
        public void AddActivityList_ShouldAddList()
        {
            // Arrange
            var mockActivity = new Mock<IActivity>();
            var activityId = Guid.NewGuid();
            mockActivity.SetupGet(a => a.Id).Returns(activityId);
            mockActivity.SetupGet(a => a.Name).Returns("Sample Activity");
            mockActivity.SetupGet(a => a.IsCompleted).Returns(false);
            mockActivity.Setup(a => a.MarkAsCompleted()).Callback(() => mockActivity.SetupGet(a => a.IsCompleted).Returns(true));

            var activityList = new ActivityList<IActivity>("Study");
            activityList.AddActivity(mockActivity.Object);

            var service = new ActivityManagementService<IActivity>();
            service.AddActivityList(activityList);

            // Act
            var activities = service.GetActivities("Study");

            // Assert
            Assert.Single(activities); // Verifica se há exatamente 1 atividade na lista
            var activityInList = activities.First();
            Assert.Equal("Sample Activity", activityInList.Name);
            Assert.Equal(activityId, activityInList.Id);
        }

        [Fact]
        public void MarkActivityAsCompleted_ShouldUpdateActivityStatus()
        {
            // Arrange
            var activity = new StudyActivity("Read Chapter 1");
            var list = new ActivityList<IActivity>("Study");
            list.AddActivity(activity);

            var service = new ActivityManagementService<IActivity>();
            service.AddActivityList(list);

            // Act
            service.MarkActivityAsCompleted(activity.Id, "Study");

            // Assert
            var activities = service.GetActivities("Study");
            var completedActivity = Assert.Single(activities);
            Assert.Equal(activity.Id, completedActivity.Id);
            Assert.True(completedActivity.IsCompleted);
        }
    }
}