using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNavaBmg.Interfaces;

namespace TesteNavaBmg.Services
{
    public class ActivityManagementService<T> where T : IActivity
    {
        private readonly Dictionary<string, List<T>> _activityLists = new();

        public void AddActivityList(ActivityList<T> list)
        {
            if (!_activityLists.ContainsKey(list.Name))
            {
                _activityLists[list.Name] = list.GetActivities().ToList();
            }
        }

        public void MarkActivityAsCompleted(Guid activityId, string listName)
        {
            if (_activityLists.ContainsKey(listName))
            {
                var activity = _activityLists[listName].FirstOrDefault(a => a.Id == activityId);
                if (activity != null)
                {
                    activity.MarkAsCompleted();
                }
            }
        }

        public IEnumerable<T> GetActivities(string listName)
        {
            if (_activityLists.ContainsKey(listName))
            {
                return _activityLists[listName];
            }
            return Enumerable.Empty<T>();
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<T>>> GetAllActivityLists()
        {
            return _activityLists.Select(kvp => new KeyValuePair<string, IEnumerable<T>>(kvp.Key, kvp.Value));
        }
    }
}
