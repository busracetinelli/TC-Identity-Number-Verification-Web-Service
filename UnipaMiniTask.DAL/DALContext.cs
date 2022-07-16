using UnipaMiniTask.DAL.Connectors;
using UnipaMiniTask.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnipaMiniTask.DAL
{
    public class DALContext
    {
        private DapperConnector _dapperConnector;

        public StudentRepository studentRepository;
        public VerificationRepository verificationRepository;

        public DALContext(string ConnectionString)
        {

            _dapperConnector = new DapperConnector(ConnectionString);

            studentRepository = StudentRepository.CreateInstance(_dapperConnector);
            verificationRepository = VerificationRepository.CreateInstance(_dapperConnector);
        }
    }
}
