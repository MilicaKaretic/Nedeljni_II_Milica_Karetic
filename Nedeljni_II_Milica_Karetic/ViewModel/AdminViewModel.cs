using Nedeljni_II_Milica_Karetic.Commands;
using Nedeljni_II_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nedeljni_II_Milica_Karetic.ViewModel
{
    class AdminViewModel : BaseViewModel
    {

        Admin admin;

        #region Constructors

        public AdminViewModel(Admin adminOpen)
        {
            admin = adminOpen;
        }

        #endregion

        #region Commands

        private ICommand updateClinic;
        public ICommand UpdateClinic
        {
            get
            {
                if (updateClinic == null)
                {
                    updateClinic = new RelayCommand(param => UpdateClinicExecute(), param => CanUpdateClinicExecute());
                }
                return updateClinic;
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

        private void UpdateClinicExecute()
        {
            UpdateClinic view = new UpdateClinic();
            view.ShowDialog();
        }

        private bool CanUpdateClinicExecute()
        {
            return true;
        }

        private void LogoutExecute()
        {
            Login log = new Login();
            admin.Close();
            log.Show();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
