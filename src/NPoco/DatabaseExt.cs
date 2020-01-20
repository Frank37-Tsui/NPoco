using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NPoco
{
    public partial class Database
    {
#if !NETSTANDARD1_3
        public DataTable ExecuteDataTable(string sql)
        {
            try
            {
                OpenSharedConnectionInternal();
                using (var cmd = CreateCommand(_sharedConnection, CommandType.Text, sql))
                {
                    var dr = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dr);
                    return dt;
                }
            }
            catch (Exception x)
            {
                OnExceptionInternal(x);
                throw;
            }
            finally
            {
                CloseSharedConnectionInternal();
            }
        }
#endif
    }

}
