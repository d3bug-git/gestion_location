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
        public ReadOnlyObservableCollection<Country> Countries => BDD.countries;
        public ReadOnlyObservableCollection<PhoneNumberCustomer> PhoneNumberCustomers => BDD.phoneNumbers;
        public pgCustomers()
        {
            InitializeComponent();
            lvCustomers.DataContext = BDD.customers;
        }
        private void RemoveCustomer(object sender, RoutedEventArgs e)
        {
            Customer selection = (Customer)lvCustomers.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer {selection.CompleteName} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveCustomer(selection); }, nameof(RemoveCustomer));
                }
            }
            grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem;
        }
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvCustomers.SelectedItem = BDD.AddCustomer("Doe", "John", "DoeJohn@example.be", "HelloWorld", false, "https://picsum.photos/150/150", "Rue des petits voyous", "11",BDD.towns.FirstOrDefault());}, nameof(AddCustomer));
            
        }
        private void ClickChips (object sender, RoutedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null) { grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem; }
        }
        private void lvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null) { grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem; }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
