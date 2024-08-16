using Microsoft.Extensions.Hosting;
using TesteNavaBmg.Interfaces;
using TesteNavaBmg.Models;
using TesteNavaBmg.Services;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton(typeof(ActivityManagementService<>));

    })
    .Build();

var managementService = new ActivityManagementService<IActivity>();

var studyList = new ActivityList<IActivity>("Study");
var activity1 = new StudyActivity("Read Chapter 1");

studyList.AddActivity(activity1);
managementService.AddActivityList(studyList);

managementService.MarkActivityAsCompleted(activity1.Id, "Study");

var activities = managementService.GetActivities("Study");
foreach (var activity in activities)
{
    Console.WriteLine($"{activity.Name} - Completed: {activity.IsCompleted}");
}