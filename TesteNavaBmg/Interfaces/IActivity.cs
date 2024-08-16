using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNavaBmg.Interfaces
{
    public interface IActivity
    {
        Guid Id { get; }
        string Name { get; }
        bool IsCompleted { get; }
        void MarkAsCompleted();
    }
}
