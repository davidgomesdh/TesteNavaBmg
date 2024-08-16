using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNavaBmg.Interfaces;

namespace TesteNavaBmg.Services
{
    public class ActivityList<T> where T : IActivity
    {
        private readonly List<T> _activities;

        public string Name { get; }

        public ActivityList(string name)
        {
            Name = name;
            _activities = new List<T>();
        }

        public void AddActivity(T activity)
        {
            _activities.Add(activity);
        }

        public void RemoveActivity(T activity)
        {
            _activities.Remove(activity);
        }

        public IEnumerable<T> GetActivities()
        {
            return _activities;
        }

        public T GetActivityById(Guid id)
        {
            return _activities.FirstOrDefault(a => a.Id == id);
        }
    }
}
