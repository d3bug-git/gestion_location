using AnnonceBDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnnonceWPF
{
    /// <summary>
    /// Logique d'interaction pour pgAdverts.xaml
    /// </summary>
    public partial class pgAdverts : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Owner> Owners => BDD.owners;
        public ReadOnlyObservableCollection<Town> Towns => BDD.towns;
        public ReadOnlyObservableCollection<Category> Categories => BDD.categories;
        public ReadOnlyObservableCollection<Book> Books => BDD.books;
        public ReadOnlyObservableCollection<Advert> Adverts => BDD.adverts;
        public ReadOnlyObservableCollection<Customer> Customers => BDD.customers;
        public pgAdverts()
        {
            InitializeComponent();
            lvAdverts.DataContext = BDD.adverts;
        }

        private void lvAdverts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvAdverts.SelectedItem != null)
            {
                grReservations.DataContext = ((Advert)lvAdverts.SelectedItem).Books;
            }
        }

        private void AddAdvert(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvAdverts.SelectedItem = BDD.AddAdvert("Nouvelle Annonce", "A remplir", 3, 3, 1,"5b","Rue des oiseaux", BDD.owners.FirstOrDefault(), BDD.categories.FirstOrDefault(), BDD.towns.FirstOrDefault()); }, nameof(AddAdvert));
        }

        private void RemoveAdvert(object sender, RoutedEventArgs e)
        {
            Advert selection = (Advert)lvAdverts.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer l'annonce {selection.Title} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveAdvert(selection); }, nameof(RemoveAdvert));
                }
            }
        }

        private void SupprimerReservation(object sender, RoutedEventArgs e)
        {
            Book selection = (Book)lvReservation.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la réservation de {selection.Advert.Title} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveBook(selection); }, nameof(SupprimerReservation));
                }
            }
            lvReservation.DataContext = ((Advert)lvAdverts.SelectedItem);
        }

        private void AjouterReservationAfficherInbox(object sender, RoutedEventArgs e)
        {
            IAE_tbAnnonce.DataContext = lvAdverts.SelectedItem;
            IAE_cmbClient.SelectedItem = null;
            IAE_DateArrival.SelectedDate = DateTime.Now;
            IAE_DateDeparture.SelectedDate = null;

            inboxAjouterReservation.Visibility = Visibility.Visible;
        }

        private void AjouterReservationConfirmerAction(object sender, RoutedEventArgs e)
        {
            int NbAdulte;
            int NbEnfant;
            bool Conversion;

            Conversion = int.TryParse(IAE_tbNbAdulte.Text, out NbAdulte);
            Conversion = int.TryParse(IAE_tbNbEnfant.Text, out NbEnfant);
            try
            {
                Book lNouvelReservation = BDD.AddBook((Advert)IAE_tbAnnonce.DataContext, (Customer)IAE_cmbClient.SelectedItem, (DateTime)IAE_DateArrival.SelectedDate, (DateTime)IAE_DateDeparture.SelectedDate, NbAdulte, NbEnfant, IAE_tbMessage.Text);
                inboxAjouterReservation.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter une réservation", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        private void AjouterReservationAnnulerAction(object sender, RoutedEventArgs e)
        {
            inboxAjouterReservation.Visibility = Visibility.Collapsed;
        }
    }
}
