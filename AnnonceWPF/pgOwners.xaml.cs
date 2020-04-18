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
using System.Linq;
using System.Collections.ObjectModel;
using AnnonceBDD;

namespace AnnonceWPF
{
    /// <summary>
    /// Logique d'interaction pour pgOwners.xaml
    /// </summary>
    public partial class pgOwners : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Customer> Customers => BDD.customers;
        public ReadOnlyObservableCollection<Town> Towns => BDD.towns;
        public ReadOnlyObservableCollection<Country> Countries => BDD.countries;
        public ReadOnlyObservableCollection<PhoneNumberCustomer> PhoneNumberCustomers => BDD.phoneNumbers;

        public pgOwners()
        {
            InitializeComponent();
            lvOwners.DataContext = BDD.owners;
        }

        private void AddOwner(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvOwners.SelectedItem = BDD.AddOwner("Doe", "John", "DoeJohn@example.be", "HelloWorld", false, "https://picsum.photos/150/150", "Rue des petits voyous", "11", BDD.towns.FirstOrDefault()); }, nameof(AddOwner));
        }

        private void RemoveOwner(object sender, RoutedEventArgs e)
        {
            Owner selection = (Owner)lvOwners.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer {selection.CompleteName} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveOwner(selection); }, nameof(RemoveOwner));
                }
            }
            grpInfoOwner.DataContext = (Customer)lvOwners.SelectedItem;
        }
        private void lvOwners_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (lvOwners.SelectedItem != null) { grpInfoOwner.DataContext = (Owner)lvOwners.SelectedItem; }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }



    }
}
