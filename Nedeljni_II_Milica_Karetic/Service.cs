using Nedeljni_II_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_II_Milica_Karetic
{
    class Service
    {
        Validation v = new Validation();
        /// <summary>
        /// Get clinic user from file
        /// </summary>
        /// <returns></returns>
        public ClinicUser getUserFile()
        {
            string location = @"..\..\ClinicAccess.txt";
            try
            {
                ClinicUser owner = new ClinicUser();
                StreamReader sr = new StreamReader(location);
                using (sr)
                {

                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(':', ' ');
                        owner.Username = lines[1];
                        owner.Password = lines[3];
                    }
                }
                return owner;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinicAdministrator> GetAllAdmins()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicAdministrator> list = new List<tblClinicAdministrator>();
                    list = (from x in context.tblClinicAdministrators select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinicMaintenance> GetAllMaintenances()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicMaintenance> list = new List<tblClinicMaintenance>();
                    list = (from x in context.tblClinicMaintenances select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<vwClinicMaintenance> GetAllMaintenancesView()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<vwClinicMaintenance> list = new List<vwClinicMaintenance>();
                    list = (from x in context.vwClinicMaintenances select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinicManager> GetAllManagers()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicManager> list = new List<tblClinicManager>();
                    list = (from x in context.tblClinicManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinicDoctor> GetAllDoctors()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicDoctor> list = new List<tblClinicDoctor>();
                    list = (from x in context.tblClinicDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinicPatient> GetAllPatients()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicPatient> list = new List<tblClinicPatient>();
                    list = (from x in context.tblClinicPatients select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblClinic> GetAllClinics()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinic> list = new List<tblClinic>();
                    list = (from x in context.tblClinics select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool IsAdmin(int userID)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicAdministrator> list = new List<tblClinicAdministrator>();
                    list = (from x in context.tblClinicAdministrators select x).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].UserID == userID)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool IsMaintenance(int userID)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicMaintenance> list = new List<tblClinicMaintenance>();
                    list = (from x in context.tblClinicMaintenances select x).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].UserID == userID)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool IsManager(int userID)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicManager> list = new List<tblClinicManager>();
                    list = (from x in context.tblClinicManagers select x).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].UserID == userID)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool IsDoctor(int userID)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicDoctor> list = new List<tblClinicDoctor>();
                    list = (from x in context.tblClinicDoctors select x).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].UserID == userID)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool IsPatient(int userID)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinicPatient> list = new List<tblClinicPatient>();
                    list = (from x in context.tblClinicPatients select x).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].UserID == userID)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Get user id based on username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User id</returns>
        public int getUserId(string username)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {

                    tblUser user = context.tblUsers.FirstOrDefault(c => c.Username == username);

                    int id = user.UserID;
                    return id;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        public vwClinicAdministrator AddAdmin(vwClinicAdministrator admin)
        {
            if(v.ValidAdmin(admin))
            {
                try
                {
                    using (ClinicDBEntities context = new ClinicDBEntities())
                    {

                        //user
                        tblUser newUser = new tblUser();
                        newUser.FirstName = admin.FirstName;
                        newUser.DateOfBirth = admin.DateOfBirth;
                        newUser.LastName = admin.LastName;
                        newUser.Username = admin.Username;
                        newUser.UserPassword = admin.UserPassword;
                        newUser.IdentificationCard = admin.IdentificationCard;
                        newUser.Gender = admin.Gender;
                        newUser.Citizenship = admin.Citizenship;


                        context.tblUsers.Add(newUser);
                        context.SaveChanges();

                        //admin
                        int id = getUserId(admin.Username);

                        tblClinicAdministrator man = new tblClinicAdministrator();
                        man.UserID = id;

                        context.tblClinicAdministrators.Add(man);
                        context.SaveChanges();

                        admin.UserID = newUser.UserID;

                        return admin;


                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception" + ex.Message.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }
        
        public tblClinic AddNewClinic(tblClinic clinic)
        {
            if (v.ValidClinic(clinic))
            {
                try
                {
                    using (ClinicDBEntities context = new ClinicDBEntities())
                    {

                        //clinic
                        tblClinic newClinic = new tblClinic();
                        newClinic.ClinicName = clinic.ClinicName;
                        newClinic.CreatingDate = clinic.CreatingDate;
                        newClinic.ClinicOwner = clinic.ClinicOwner;
                        newClinic.ClinicAddress = clinic.ClinicAddress;
                        newClinic.RoomsPerFloor = clinic.RoomsPerFloor;
                        newClinic.ClinicFloorNumber = clinic.ClinicFloorNumber;
                        newClinic.Garden = clinic.Garden;
                        newClinic.Balcony = clinic.Balcony;
                        newClinic.EmergencyVehicleParkingLoots = clinic.EmergencyVehicleParkingLoots;
                        newClinic.InvalidVehicleParkingLoots = clinic.InvalidVehicleParkingLoots;

                        context.tblClinics.Add(newClinic);
                        context.SaveChanges();                      

                        clinic.ClinicID = newClinic.ClinicID;

                        return clinic;


                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception" + ex.Message.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
