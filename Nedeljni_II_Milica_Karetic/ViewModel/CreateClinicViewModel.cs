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
    class CreateClinicViewModel : BaseViewModel
    {

        CreateClinic medicalView;
        Service service = new Service();


        #region Constructors

        public CreateClinicViewModel(CreateClinic medicalViewOpen)
        {
            medicalView = medicalViewOpen;
            Clinic = new tblClinic();
        }

        #endregion

        #region Properties

        private tblClinic clinic;

        public tblClinic Clinic
        {
            get { return clinic; }
            set
            {
                clinic = value;
                OnPropertyChanged("Clinic");
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
            if (service.AddNewClinic(Clinic) != null)
            {
                MessageBox.Show("Successfully created clinic.");
                medicalView.Close();
            }
        }

        private bool CanSaveExecute()
        {
           
                return true;
            
        }

        private void CloseExecute()
        {
            medicalView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }


        #endregion
    }
}
