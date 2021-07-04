using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        public List<Domain.Task> GetTasks();
        public Domain.Task GetTask(Guid id);
        public void UpdateTask(Domain.Task task);
        public void AddTask(Domain.Task task);
    }
}
