using Nedeljni_II_Milica_Karetic.Commands;
using Nedeljni_II_Milica_Karetic.Model;
using Nedeljni_II_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_II_Milica_Karetic.ViewModel
{
    class LoginViewModel : BaseViewModel
    {

        Login view;
        Service service = new Service();

        #region Constructor
        public LoginViewModel(Login loginView)
        {
            view = loginView;
            user = new tblUser();
            UserList = service.GetAllUsers().ToList();
            AdminList = service.GetAllAdmins().ToList();
            ManagerList = service.GetAllManagers().ToList();
            MaintenanceList = service.GetAllMaintenances().ToList();
            DoctorList = service.GetAllDoctors().ToList();
            PatientList = service.GetAllPatients().ToList();


        }
        #endregion

        #region Property
        /// <summary>
        /// Login info label
        /// </summary>
        private string labelInfo;
        public string LabelInfo
        {
            get
            {
                return labelInfo;
            }
            set
            {
                labelInfo = value;
                OnPropertyChanged("LabelInfo");
            }
        }

        /// <summary>
        /// Used for saving the current user
        /// </summary>
        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        /// <summary>
        /// List of all users in the application
        /// </summary>
        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        /// <summary>
        /// Used for saving the current doctor
        /// </summary>
        private tblClinicDoctor doctor;
        public tblClinicDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        /// <summary>
        /// List of all doctors in the application
        /// </summary>
        private List<tblClinicDoctor> doctorList;
        public List<tblClinicDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
            }
        }

        /// <summary>
        /// Used for saving the current patient
        /// </summary>
        private tblClinicPatient patient;
        public tblClinicPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        /// <summary>
        /// List of all patients in the application
        /// </summary>
        private List<tblClinicPatient> patientList;
        public List<tblClinicPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }


        /// <summary>
        /// Used for saving the current admin
        /// </summary>
        private tblClinicAdministrator admin;
        public tblClinicAdministrator Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        /// <summary>
        /// List of all admins in the application
        /// </summary>
        private List<tblClinicAdministrator> adminList;
        public List<tblClinicAdministrator> AdminList
        {
            get
            {
                return adminList;
            }
            set
            {
                adminList = value;
                OnPropertyChanged("AdminList");
            }
        }

        /// <summary>
        /// Used for saving the current Maintenance
        /// </summary>
        private tblClinicMaintenance maintenance;
        public tblClinicMaintenance Maintenance
        {
            get
            {
                return maintenance;
            }
            set
            {
                maintenance = value;
                OnPropertyChanged("Maintenance");
            }
        }

        /// <summary>
        /// List of all Maintenances in the application
        /// </summary>
        private List<tblClinicMaintenance> maintenanceList;
        public List<tblClinicMaintenance> MaintenanceList
        {
            get
            {
                return maintenanceList;
            }
            set
            {
                maintenanceList = value;
                OnPropertyChanged("MaintenanceList");
            }
        }

        /// <summary>
        /// Used for saving the current manager
        /// </summary>
        private tblClinicManager manager;
        public tblClinicManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        /// <summary>
        /// List of all managers in the application
        /// </summary>
        private List<tblClinicManager> managerList;
        public List<tblClinicManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }
        #endregion

        #region Commands
        

        /// <summary>
        /// Command used to log the user into the application
        /// </summary>
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
        }

        //public object LoggedUser { get; private set; }
        //public object LoggedDoctor { get; private set; }

        /// <summary>
        /// Login command execute and save logged in user
        /// </summary>
        /// <param name="obj"></param>
        private void LoginExecute(object obj)
        {
            string password = (obj as PasswordBox).Password;
            bool found = false;
            string username = User.Username;
            ClinicUser cuser = service.getUserFile();

            if (User.Username == cuser.Username && password == cuser.Password)
            {
                Master add = new Master();
                view.Close();
                add.Show();
            }
            else if(UserList.Any())
            {
                for (int i = 0; i < UserList.Count; i++)
                {
                    if (User.Username == UserList[i].Username && password == UserList[i].UserPassword)
                    {

                        LoggedUser.CurrentUser = new tblUser
                        {
                            UserID = UserList[i].UserID,
                            FirstName = UserList[i].FirstName,
                            LastName = UserList[i].LastName,
                            IdentificationCard = UserList[i].IdentificationCard,
                            Gender = UserList[i].Gender,
                            Username = UserList[i].Username,
                            UserPassword = UserList[i].UserPassword,
                            DateOfBirth = UserList[i].DateOfBirth,
                            Citizenship = UserList[i].Citizenship
                        };
                        LabelInfo = "Logged in";
                        found = true;

                        if(service.IsAdmin(LoggedUser.CurrentUser.UserID))
                        {
                            Admin admin = new Admin();
                            view.Close();
                            admin.Show();
                        }
                        else if (service.IsDoctor(LoggedUser.CurrentUser.UserID))
                        {

                        }
                        else if (service.IsMaintenance(LoggedUser.CurrentUser.UserID))
                        {

                        }
                        else if (service.IsManager(LoggedUser.CurrentUser.UserID))
                        {

                        }
                        else if (service.IsPatient(LoggedUser.CurrentUser.UserID))
                        {

                        }

                        break;
                    }
                }

                }


                if (found == false)
                {
                    LabelInfo = "Wrong Username or Password";
                }
            }
            
        }
        #endregion
    }

