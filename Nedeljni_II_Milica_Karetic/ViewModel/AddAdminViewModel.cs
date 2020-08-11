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
    class AddAdminViewModel : BaseViewModel
    {
        AddAdmin adminView;
        Service service = new Service();

        #region Constructors

        public AddAdminViewModel(AddAdmin adminViewOpen)
        {
            adminView = adminViewOpen;
            Admin = new vwClinicAdministrator();
            Genders = GetBothGender();
        }

        #endregion

        #region Properties

        private vwClinicAdministrator admin;

        public vwClinicAdministrator Admin
        {
            get { return admin; }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private List<string> genders;

        public List<string> Genders
        {
            get { return genders; }
            set
            {
                genders = value;
                OnPropertyChanged("Genders");
            }
        }

        #endregion

        #region Commands

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions

        private void SaveExecute()
        {
            Admin.Gender = Gender;

            if(service.AddAdmin(Admin) != null)
            {
                MessageBox.Show("Successfully created new admin.");
                adminView.Close();
            }
                    

        }

        private bool CanSaveExecute()
        {

            return true;

        }

        private void CloseExecute()
        {
            adminView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private List<string> GetBothGender()
        {
            List<string> genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            return genders;
        }

        #endregion
    }
}
