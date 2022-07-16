using UnipaMiniTask.DAL;

namespace UnipaMiniTask.BLL.Kernel
{
    public class BaseService
    {
        protected static DALContext _dalContext;
        protected static object _threadSyncObject = new object();
    }
}
