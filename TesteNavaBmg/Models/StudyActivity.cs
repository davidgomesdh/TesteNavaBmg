using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNavaBmg.Interfaces;

namespace TesteNavaBmg.Models
{
    public class StudyActivity : IActivity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        public StudyActivity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}