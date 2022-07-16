using UnipaMiniTask.DAL.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnipaMiniTask.DAL.Kernel
{
    public class BaseRepository
    {
        protected static DapperConnector _dapperConnector;

        protected static object _threadSyncObject = new object();
    }
}
