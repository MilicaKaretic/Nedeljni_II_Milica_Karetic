using Nedeljni_II_Milica_Karetic.Commands;
using Nedeljni_II_Milica_Karetic.Model;
using Nedeljni_II_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nedeljni_II_Milica_Karetic.ViewModel
{
    class MasterViewModel :  BaseViewModel
    {
        Master master;

        #region Constructors

        public MasterViewModel(Master masterOpen)
        {
            master = masterOpen;
        }

        #endregion

        #region Commands

        private ICommand createAdmin;
        public ICommand CreateAdmin
        {
            get
            {
                if (createAdmin == null)
                {
                    createAdmin = new RelayCommand(param => CreateAdminExecute(), param => CanCreateAdminExecute());
                }
                return createAdmin;
            }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        #endregion

        #region Functions

        private void CreateAdminExecute()
        {
            AddAdmin view = new AddAdmin();
            view.ShowDialog();
        }

        private bool CanCreateAdminExecute()
        {
            try
            {
                using (ClinicDBEntities db = new ClinicDBEntities())
                {
                    if (db.tblClinicAdministrators.Any())
                    {
                        return false;
                    }
                    else return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private void LogoutExecute()
        {
            Login log = new Login();
            master.Close();
            log.Show();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
