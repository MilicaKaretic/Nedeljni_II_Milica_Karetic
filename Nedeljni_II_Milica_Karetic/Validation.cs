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
                return true;
            else
            {
                MessageBox.Show("Wrong Identification Card number. Must have 9 digits.");
                return false;
            }

        }

       
    }
}
