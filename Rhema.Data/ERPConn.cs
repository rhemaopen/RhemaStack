﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPConnect;
using Newtonsoft.Json;
using Rhema.Core;
using Rhema.Core.Infrastructure;

namespace Rhema.Data
{
    /// <summary>
    /// Class SapConn.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ERPConn :  IDisposable, IERPConn
    {
        private ERPConnect.R3Connection _connectionSAP;

        public ERPConn(string connectionInfo)
        {
            var fileProvider = EngineContext.Current.Resolve<IRhemaFileProvider>();
            var filePath = fileProvider.MapPath(connectionInfo);

            if (fileProvider.FileExists(filePath))
            {
                using (var reader = new StringReader(fileProvider.ReadAllText(filePath, Encoding.UTF8)))
                {
                    var conn = JsonConvert.DeserializeObject<ConnConf>(reader.ReadToEnd());

                    //R3Connection connectionSAP = new R3Connection();
                    try
                    {
                        _connectionSAP = new R3Connection(conn.Server, conn.Sysid, conn.User, conn.Password, conn.Lang, conn.Client);
                        ConnectionSAP = _connectionSAP;


                    }
                    catch (Exception ex)
                    {

                        _connectionSAP.Dispose();

                        //this.logHandler.Error(MethodBase.GetCurrentMethod().Name, "Call ERGetPConnection Fail: " + ex.Message);
                    }
                }
            }
           
            

        }

     

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _connectionSAP.Dispose();
        }

        public R3Connection ConnectionSAP { get; }

        public void Open()
        {
            if (!_connectionSAP.Ping())
            {
                _connectionSAP.Open();
            }
        }

        public void Close()
        {
            _connectionSAP.Close();
        }
    }
}
