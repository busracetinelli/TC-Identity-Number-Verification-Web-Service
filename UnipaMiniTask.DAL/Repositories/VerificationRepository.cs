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
    public class VerificationRepository : BaseRepository
    {
        private static volatile VerificationRepository _instance;
        private VerificationRepository(DapperConnector DapperConnector)
        {

            _dapperConnector = DapperConnector;
        }
        public static VerificationRepository CreateInstance(DapperConnector DapperConnector)
        {

            if (_instance == null)
                lock (_threadSyncObject)
                {
                    if (_instance == null)
                        _instance = new VerificationRepository(DapperConnector);
                }

            return _instance;
        }
        public IEnumerable<Verification> Select(int? id = null)
        {

            return _dapperConnector.SelectFromProcedure<Verification>("usp_VerificationSelect", id);
        }
        public Verification Create(Verification Model)
        {

            return _dapperConnector.InsertFromProcedure<Verification>("usp_VerificationCreate", Model);
        }
        public void Update(Verification Model)
        {

            _dapperConnector.UpdateFromProcedure<Verification>("usp_VerificationUpdate", Model);
        }
        public bool Delete(int? id = null)
        {

            return _dapperConnector.DeleteFromProcedure("usp_VerificationDelete", id);
        }
    }
}
