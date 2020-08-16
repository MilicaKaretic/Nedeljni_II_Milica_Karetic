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
    class UpdateMaintanceViewModel : BaseViewModel
    {
        #region Objects

        UpdateMaintance updateView;
        Service service = new Service();

        #endregion

        #region Constructors

        public UpdateMaintanceViewModel(UpdateMaintance updateViewOpen)
        {
            updateView = updateViewOpen;
            Genders = GetBothGender();
            Maintance = new vwClinicMaintenance();
        }

        public UpdateMaintanceViewModel(UpdateMaintance updateViewOpen, vwClinicMaintenance updateMaintance)
        {
            updateView = updateViewOpen;
            Maintance = updateMaintance;
            Genders = GetBothGender();
        }

        #endregion

        #region Proeprties

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

        private List<string> GetBothGender()
        {
            List<string> genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            return genders;
        }


        private void SaveExecute()
        {
            
            try
            {
                tblClinicMaintenance updateMaintance = new tblClinicMaintenance();
                tblUser updateUser = new tblUser();
                using (ClinicDBEntities db = new ClinicDBEntities())
                {
                    if(Maintance.MaintenanceID == 0)
                    {
                        Maintance.Gender = Gender;

                        if(service.IsValidMaintenance(Maintance))
                        {
                            updateUser.FirstName = Maintance.FirstName;
                            updateUser.LastName = Maintance.LastName;
                            updateUser.IdentificationCard = Maintance.IdentificationCard;
                            updateUser.Gender = Maintance.Gender;
                            updateUser.DateOfBirth = Maintance.DateOfBirth;
                            updateUser.Citizenship = Maintance.Citizenship;
                            updateUser.Username = Maintance.Username;
                            updateUser.UserPassword = Maintance.UserPassword;

                            db.tblUsers.Add(updateUser);
                            db.SaveChanges();

                            Maintance.UserID = updateUser.UserID;

                            updateMaintance.DisabledAccessabilityResponsibility = Maintance.DisabledAccessabilityResponsibility;
                            updateMaintance.UserID = Maintance.UserID;
                            if (Maintance.DisabledAccessabilityResponsibility == false)
                            {
                                updateMaintance.ClinicExtentionAllowed = true;
                                Maintance.ClinicExtentionAllowed = true;
                            }
                            else
                            {
                                updateMaintance.ClinicExtentionAllowed = false;
                                Maintance.ClinicExtentionAllowed = false;
                            }

                            db.tblClinicMaintenances.Add(updateMaintance);
                            db.SaveChanges();

                            Maintance.MaintenanceID = updateMaintance.MaintenanceID;

                            MessageBox.Show("Maintance Created Successfully!");

                            Admin ad = new Admin();
                            updateView.Close();
                            ad.Show();
                        }
                       
                    }
                    else
                    {
                        if(service.IsValidMaintenance(Maintance))
                        {
                            updateMaintance = db.tblClinicMaintenances.Where(m => m.UserID == Maintance.UserID).FirstOrDefault();
                            updateUser = db.tblUsers.Where(m => m.UserID == Maintance.UserID).FirstOrDefault();


                            updateUser.FirstName = Maintance.FirstName;
                            updateUser.LastName = Maintance.LastName;
                            updateUser.IdentificationCard = Maintance.IdentificationCard;
                            updateUser.Gender = Maintance.Gender;
                            updateUser.DateOfBirth = Maintance.DateOfBirth;
                            updateUser.Citizenship = Maintance.Citizenship;
                            updateUser.Username = Maintance.Username;
                            updateUser.UserPassword = Maintance.UserPassword;


                            updateMaintance.DisabledAccessabilityResponsibility = Maintance.DisabledAccessabilityResponsibility;
                            if (Maintance.DisabledAccessabilityResponsibility == false)
                            {
                                updateMaintance.ClinicExtentionAllowed = true;
                                Maintance.ClinicExtentionAllowed = true;
                            }
                            else
                            {
                                updateMaintance.ClinicExtentionAllowed = false;
                                Maintance.ClinicExtentionAllowed = false;
                            }

                            db.SaveChanges();

                            MessageBox.Show("Maintance Updated Successfully!");
                            Admin ad = new Admin();
                            updateView.Close();
                            ad.Show();
                        }
                        
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        private void CloseExecute()
        {
            updateView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
