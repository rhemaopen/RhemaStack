using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Rhema.Core.Domain;

namespace Rhema.Data
{

    /// <summary>
    /// Class ERPSessionFactory.
    /// </summary>
    public class ERPSessionFactory
    {

        private static IERPConn CreateConnection(IConfiguration configuration, ERPType dataType = ERPType.ECC6, string connStrKey = "")
        {
            ERPConn conn;
            switch (dataType)
            {
                case ERPType.ECC6:
                    conn = new ERPConn(connStrKey);
                    break;
                default:
                    conn = new ERPConn(connStrKey);
                    break;
            }

            return conn;
        }



        public static IERPConn CreateSession(IConfiguration configuration, ERPType databaseType, string key)
        {
            var isDefined = Enum.IsDefined(typeof(ERPType), databaseType);
            if (!isDefined)
            {
                throw new NotSupportedException();
            }
            return CreateConnection(configuration, databaseType, key);

        }
    }
}
