using SharedFrameWork.Application;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedFrameWork.Infrastructure
{
    public class DapperContextHelper : IContextHelper,IDisposable
    {
        private bool _disposed;
        private SqlConnection _connection;
        private static object _locker = new();
        public string ConnectionString { get; }


        public DapperContextHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlConnection Create()
        {
            lock (_locker)
            {
                if (_connection == null)
                    _connection = new SqlConnection(ConnectionString);

                return _connection;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed)
                return; 

            if(dispose)
            {
                _connection.Dispose();
                _locker = null;
            }

            _disposed = true;
        }
    }
}
