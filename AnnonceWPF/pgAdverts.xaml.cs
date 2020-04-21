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
        public pgAdverts()
        {
            InitializeComponent();
            grAnnonces.DataContext = BDD.adverts;
        }

        private void lvAdverts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
