using Nedeljni_II_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nedeljni_II_Milica_Karetic
{
    class Validation
    {

        public bool ValidAdmin(vwClinicAdministrator admin)
        {
            if (admin.IdentificationCard.Length == 9)
            {
                if(UniqueIDCard(admin.IdentificationCard))
                {
                    if(UniqueUsername(admin.Username))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("There is user with that username. Try again.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("There is user with that Identification Card number. Try again.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong Identification Card number. Must have 9 digits.");
                return false;
            }

        }

        private bool UniqueUsername(string username)
        {
            Service service = new Service();
            List<tblUser> users = service.GetAllUsers();

            int a = 0;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    a++;
                    break;
                }
            }
            if (a != 0)
                return false;
            else
                return true;
        }

        private bool UniqueIDCard(string IDcard)
        {

            Service service = new Service();
            List<tblUser> users = service.GetAllUsers();

            int a = 0;

            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].IdentificationCard == IDcard)
                {
                    a++;
                    break;
                }
            }
            if (a != 0)
                return false;
            else
                return true;
        }

        public bool AnyClinics()
        {
            try
            {
                using (ClinicDBEntities db = new ClinicDBEntities())
                {
                    if (db.tblClinics.Any())
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

        public bool ValidClinic(tblClinic clinic)
        {
            return true;
        }



    }
}
