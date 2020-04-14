using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnnonceBDD;

namespace AnnonceWPF
{
    /// <summary>
    /// Logique d'interaction pour pgOwners.xaml
    /// </summary>
    public partial class pgOwners : Page
    {
       BDDSingleton BDD = BDDSingleton.Instance;

            public pgOwners()
            {
                InitializeComponent();
                grpOwners.DataContext = BDD.owners;
            }

            private void AddOwner(object sender, RoutedEventArgs e)
            {
            }

            private void RemoveOwner(object sender, RoutedEventArgs e)
            {                
            }
        
    }
}
