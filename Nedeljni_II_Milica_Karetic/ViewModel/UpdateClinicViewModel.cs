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
    class UpdateClinicViewModel : BaseViewModel
    {
        #region Objects

        UpdateClinic clinicView;

        #endregion

        #region Constructors

        public UpdateClinicViewModel(UpdateClinic clinicViewOpen)
        {
            clinicView = clinicViewOpen;
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
            try
            {
                tblClinic onlyInstution = new tblClinic();
                using (ClinicDBEntities db = new ClinicDBEntities())
                {
                    onlyInstution = db.tblClinics.Where(i => i.ClinicID > 0).FirstOrDefault();

                    onlyInstution.ClinicOwner = Clinic.ClinicOwner;
                    onlyInstution.InvalidVehicleParkingLoots = Clinic.InvalidVehicleParkingLoots;
                    onlyInstution.EmergencyVehicleParkingLoots = Clinic.EmergencyVehicleParkingLoots;

                    db.SaveChanges();
                }
                MessageBox.Show("Medical Clinic Updated Successfully!");
                clinicView.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            tblClinic onlyInstution = new tblClinic();
            using (ClinicDBEntities db = new ClinicDBEntities())
            {
                onlyInstution = db.tblClinics.Where(i => i.ClinicID > 0).FirstOrDefault();
            }

            if (Clinic.InvalidVehicleParkingLoots < onlyInstution.InvalidVehicleParkingLoots
                     || Clinic.EmergencyVehicleParkingLoots < onlyInstution.EmergencyVehicleParkingLoots)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CloseExecute()
        {
            clinicView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
