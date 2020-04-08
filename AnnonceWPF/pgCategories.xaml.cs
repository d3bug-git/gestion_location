using AnnonceBDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    /// Logique d'interaction pour pgCategories.xaml
    /// </summary>
    public partial class pgCategories : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Advert> Adverts => BDD.adverts;
        public ReadOnlyObservableCollection<Owner> Owners => BDD.owners;
        public pgCategories()
        {
            InitializeComponent();
            grpCategories.DataContext = BDD.categories;
        }
        private void lvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)lvCategories.SelectedItem;
            if (category != null)
            {
                grpAnnonces.DataContext = category.Adverts;
            }
        }
        private void AjouterCategorie(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvCategories.SelectedItem = BDD.AddCategory("Nouvelle Catégorie", "Description","Avatar"); }, nameof(AjouterCategorie));
        }
        private void SupprimerCategorie(object sender, RoutedEventArgs e)
        {
            Category selection = (Category)lvCategories.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la catégorie {selection.Title} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveCategory(selection); }, nameof(SupprimerCategorie));
                }
            }
        }
    }
}
