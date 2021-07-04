using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.Data
{
    public interface IDataContext
    {
        public List<Domain.Task> Tasks();

    }
}
