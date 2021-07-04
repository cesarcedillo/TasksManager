using PerfectChannel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Infrastructure.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly IDataContext _context;

        public TaskRepository(
            IDataContext context
            )
        {
            _context = context;
        }

        public List<Domain.Task> GetTasks()
        {
            try
            {
                var tasks = _context.Tasks();

                return tasks;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }

        public Domain.Task GetTask(Guid id)
        {
            try
            {

                var value = _context.Tasks().Where((t) => t.Id == id).SingleOrDefault();

                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }

        public void UpdateTask(Domain.Task task)
        {
            try
            {

                var value = _context.Tasks().Where((t) => t.Id == task.Id).SingleOrDefault();

                if (value != null)
                {
                    value.Pending = task.Pending;
                    value.Text = task.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }

        public void AddTask(Domain.Task task)
        {
            try
            {

                var tasks = _context.Tasks();
                tasks.Add(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }

    }
}
