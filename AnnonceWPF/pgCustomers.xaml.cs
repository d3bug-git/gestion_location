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
using System.Collections.ObjectModel;
using AnnonceBDD;

namespace AnnonceWPF
{
    /// <summary>
    /// Logique d'interaction pour pgCustomers.xaml
    /// </summary>
    public partial class pgCustomers : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Customer> Customers => BDD.customers;
        public ReadOnlyObservableCollection<Town> Towns => BDD.towns;
        public pgCustomers()
        {
            InitializeComponent();
            lvCustomers.DataContext = BDD.customers;
        }
        private void RemoveCustomer(object sender, RoutedEventArgs e)
        {

        }
        private void AddCustomer(object sender, RoutedEventArgs e)
        {

        }
        private void lvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null) { grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem; }
        }

        private void lvCustomers_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
