using Dapper;
using UnipaMiniTask.CORE;
using UnipaMiniTask.DAL.Connectors;
using UnipaMiniTask.DAL.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnipaMiniTask.DAL.Repositories
{
    public class StudentRepository : BaseRepository
    {
        private static volatile StudentRepository _instance;
        private StudentRepository(DapperConnector DapperConnector)
        {

            _dapperConnector = DapperConnector;
        }
        public static StudentRepository CreateInstance(DapperConnector DapperConnector)
        {

            if (_instance == null)
                lock (_threadSyncObject)
                {
                    if (_instance == null)
                        _instance = new StudentRepository(DapperConnector);
                }

            return _instance;
        }
        public IEnumerable<Student> Select(int? id = null)
        {

            return _dapperConnector.SelectFromProcedure<Student>("usp_StudentSelect", id);
        }
        public Student Create(Student Model)
        {

            return _dapperConnector.InsertFromProcedure<Student>("usp_StudentCreate", Model);
        }
        public void Update(Student Model)
        {

            _dapperConnector.UpdateFromProcedure<Student>("usp_StudentUpdate", Model);
        }
        public bool Delete(int? id = null)
        {

            return _dapperConnector.DeleteFromProcedure("usp_StudentDelete", id);
        }
    }
}
