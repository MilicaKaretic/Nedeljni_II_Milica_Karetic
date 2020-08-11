using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Milica_Karetic.Model
{
    /// <summary>
    /// Current logged in user data
    /// </summary>
    public static class LoggedUser
    {
        /// <summary>
        /// Current user
        /// </summary>
        private static tblUser currentUser;
        public static tblUser CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
    }
}
