using UnipaMiniTask.BLL.Services;
using UnipaMiniTask.DAL;

namespace UnipaMiniTask.BLL
{
    public class BLLContext
    {
        private readonly DALContext _dalContext;

        public StudentService studentService;
        public VerificationService verificationService;

        public BLLContext(string ConnectionString)
        {

            _dalContext = new DALContext(ConnectionString);

            studentService = StudentService.CreateInstance(_dalContext);
            verificationService = VerificationService.CreateInstance(_dalContext);
        }
    }
}
