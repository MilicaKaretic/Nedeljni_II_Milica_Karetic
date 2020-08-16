﻿using Nedeljni_II_Milica_Karetic.Model;
using Nedeljni_II_Milica_Karetic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nedeljni_II_Milica_Karetic.View
{
    /// <summary>
    /// Interaction logic for UpdateClinic.xaml
    /// </summary>
    public partial class UpdateClinic : Window
    {
        public UpdateClinic()
        {
            InitializeComponent();
            this.DataContext = new UpdateClinicViewModel(this);
        }

        /// <summary>
        /// User can only imput numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
