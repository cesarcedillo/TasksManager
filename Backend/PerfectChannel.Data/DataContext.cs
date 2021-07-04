using System;
using System.Collections.Generic;

namespace PerfectChannel.Data
{


    public class DataContext : IDataContext
    {
        private readonly List<Domain.Task> _tasks;
        public DataContext()
        {
            try
            {
                _tasks = new List<Domain.Task>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }

        public List<Domain.Task> Tasks()
        {
            try
            {
                return _tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
                throw ex;
            }
        }
    }
}
