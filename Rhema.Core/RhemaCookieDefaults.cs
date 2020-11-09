using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhema.Core
{

    /// <summary>
    /// Class RhemaCookieDefaults.
    /// </summary>
    public static class RhemaCookieDefaults
    {
        /// <summary>
        /// Gets the cookie name prefix
        /// </summary>
        public static string Prefix => ".Rhema";


        /// <summary>
        /// Gets the account cookie.
        /// </summary>
        /// <value>The account cookie.</value>
        public static string AccountCookie => ".Account";
        public static string AuthenticationCookie => ".Authentication";

        
    }
}
