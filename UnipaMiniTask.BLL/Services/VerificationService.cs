using UnipaMiniTask.BLL.Kernel;
using UnipaMiniTask.CORE;
using UnipaMiniTask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnipaMiniTask.BLL.Services
{
    public class VerificationService : BaseService
    {
        private static volatile VerificationService _instance;
        private VerificationService(DALContext dalContext)
        {

            _dalContext = dalContext;
        }
        public static VerificationService CreateInstance(DALContext dalContext)
        {

            if (_instance == null)
                lock (_threadSyncObject)
                {
                    if (_instance == null)
                        _instance = new VerificationService(dalContext);
                }

            return _instance;
        }

        public Verification Add(Verification Model)
        {
            Model.VerificationDate = DateTime.Now;
            return _dalContext.verificationRepository.Create(Model);
        }
        public void Update(Verification Model)
        {
            Model.VerificationDate = DateTime.Now;
            _dalContext.verificationRepository.Update(Model);
        }
        public bool Delete(int? id)
        {

            return _dalContext.verificationRepository.Delete(id);
        }

        public bool DeleteAll()
        {

            return _dalContext.verificationRepository.Delete();
        }

        public Verification Get(int? id)
        {

            return _dalContext.verificationRepository.Select(id).FirstOrDefault();
        }

        public List<Verification> GetAll()
        {

            return _dalContext.verificationRepository.Select().ToList();
        }
    }
}
