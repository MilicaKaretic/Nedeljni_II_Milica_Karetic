using Nedeljni_II_Milica_Karetic.Commands;
using Nedeljni_II_Milica_Karetic.Model;
using Nedeljni_II_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_II_Milica_Karetic.ViewModel
{
    class AdminViewModel : BaseViewModel
    {

        Admin admin;
        Service service = new Service();

        #region Constructors

        public AdminViewModel(Admin adminOpen)
        {
            admin = adminOpen;
            MaintanceList = service.GetAllMaintenancesView();
        }

        #endregion

        #region Properties

        private vwClinicMaintenance maintance;

        public vwClinicMaintenance Maintance
        {
            get { return maintance; }
            set
            {
                maintance = value;
                OnPropertyChanged("Maintance");
            }
        }

        private List<vwClinicMaintenance> maintanceList;

        public List<vwClinicMaintenance> MaintanceList
        {
            get { return maintanceList; }
            set
            {
                maintanceList = value;
                OnPropertyChanged("MaintanceList");
            }
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

        private ICommand updateMaintance;
        public ICommand UpdateMaintance
        {
            get
            {
                if (updateMaintance == null)
                {
                    updateMaintance = new RelayCommand(param => UpdateMaintanceExecute(), param => CanUpdateMaintanceExecute());
                }
                return updateMaintance;
            }
        }

        private ICommand deleteMaintance;
        public ICommand DeleteMaintance
        {
            get
            {
                if (deleteMaintance == null)
                {
                    deleteMaintance = new RelayCommand(param => DeleteMaintanceExecute(), param => CanDeleteMaintanceExecute());
                }
                return deleteMaintance;
            }
        }

        private ICommand createMaintance;
        public ICommand CreateMaintance
        {
            get
            {
                if (createMaintance == null)
                {
                    createMaintance = new RelayCommand(param => CreateMaintanceExecute(), param => CanCreateMaintanceExecute());
                }
                return createMaintance;
            }
        }

        #endregion

        #region Functions

        private void CreateMaintanceExecute()
        {

        }

        private bool CanCreateMaintanceExecute()
        {
            return true;
        }

        private void UpdateClinicExecute()
        {
            UpdateClinic view = new UpdateClinic();
            view.ShowDialog();
        }

        private bool CanUpdateClinicExecute()
        {
            return true;
        }

        private void UpdateMaintanceExecute()
        {
            UpdateMaintance view = new UpdateMaintance(Maintance);
            view.Show();
            admin.Close();
        }

        private bool CanUpdateMaintanceExecute()
        {
            return true;
        }

        private void DeleteMaintanceExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you Sure?", "Confirm Deleting", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (ClinicDBEntities db = new ClinicDBEntities())
                        {
                            tblClinicMaintenance maintance = db.tblClinicMaintenances.Where(m => m.MaintenanceID == Maintance.MaintenanceID).FirstOrDefault();
                            tblUser userM = db.tblUsers.Where(u => u.UserID == Maintance.UserID).FirstOrDefault();

                            db.tblClinicMaintenances.Remove(maintance);
                            db.tblUsers.Remove(userM);
                            
                            db.SaveChanges();
                        }
                        MessageBox.Show("Maintance Deleted.");
                        MaintanceList = service.GetAllMaintenancesView();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanDeleteMaintanceExecute()
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
