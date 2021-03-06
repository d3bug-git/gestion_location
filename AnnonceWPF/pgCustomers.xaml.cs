﻿using System;
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
        public ReadOnlyObservableCollection<Advert> Adverts => BDD.adverts;
        public ReadOnlyObservableCollection<Picture> Pictures => BDD.pictures;
        public ReadOnlyObservableCollection<Book> Books => BDD.books;
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
            Statics.TryCatch(() => { lvCustomers.SelectedItem = BDD.AddCustomer("Doe", "John", "DoeJohn@example.be", "HelloWorld", false, "https://picsum.photos/150/150", "Rue des petits voyous", "11", BDD.towns.FirstOrDefault()); }, nameof(AddCustomer));

        }
        private void ClickChips(object sender, RoutedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null) { grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem; }
        }
        private void lvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomers.SelectedItem != null)
            {
                grpInfoCustomer.DataContext = (Customer)lvCustomers.SelectedItem;
                grpLocation.DataContext = ((Customer)lvCustomers.SelectedItem).Books;
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void AddPhoneNumberDisplayInbox(object sender, RoutedEventArgs e)
        {
            inboxAddPhoneNumber.Visibility = Visibility.Visible;
        }
        private void AddPhoneConfirmAction(object sender, RoutedEventArgs e)
        {
            try
            {
                PhoneNumberCustomer lNewPhoneNumber = BDD.AddPhoneNumberCustomer(IAE_tbPhoneNumber.Text, (Customer)lvCustomers.SelectedItem, (Country)cbCountry.SelectedItem);
                inboxAddPhoneNumber.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un numéro de téléphone", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        private void AddPhoneCancelAction(object sender, RoutedEventArgs e)
        {
            inboxAddPhoneNumber.Visibility = Visibility.Collapsed;
        }

        private void RemovePhoneNumber(object sender, RoutedEventArgs e)
        {
            PhoneNumberCustomer selection = (PhoneNumberCustomer)lbTel.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le numéro de téléphone, {selection.Tel}, de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemovePhoneNumberCustomer(selection); }, nameof(RemovePhoneNumber));
                }
            }
        }
    }
}
