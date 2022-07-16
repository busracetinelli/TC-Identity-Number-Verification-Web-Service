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
    public class StudentService : BaseService
    {
        private static volatile StudentService _instance;
        private StudentService(DALContext dalContext)
        {

            _dalContext = dalContext;
        }
        public static StudentService CreateInstance(DALContext dalContext)
        {

            if (_instance == null)
                lock (_threadSyncObject)
                {
                    if (_instance == null)
                        _instance = new StudentService(dalContext);
                }

            return _instance;
        }

        public Student Add(Student Model)
        {
            return _dalContext.studentRepository.Create(Model);
        }
        public void Update(Student Model)
        {

            _dalContext.studentRepository.Update(Model);
        }
        public bool Delete(int? id)
        {

            return _dalContext.studentRepository.Delete(id);
        }

        public bool DeleteAll()
        {

            return _dalContext.studentRepository.Delete();
        }

        public Student Get(int? id)
        {

            return _dalContext.studentRepository.Select(id).FirstOrDefault();
        }

        public List<Student> GetAll()
        {

            return _dalContext.studentRepository.Select().ToList();
        }
    }
}
