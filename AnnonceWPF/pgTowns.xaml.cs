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
    /// Logique d'interaction pour pgTowns.xaml
    /// </summary>
    public partial class pgTowns : Page
    {
        public ReadOnlyObservableCollection<Country> Countries => BDD.countries;

        BDDSingleton BDD = BDDSingleton.Instance;

        public pgTowns()
        {
            InitializeComponent();
            grpListeVilles.DataContext = BDD.towns;
        }

        private void AjouterVille(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvVilles.SelectedItem = BDD.AddTown("Nouvelle Ville", "CP", BDD.countries.FirstOrDefault()); }, nameof(AjouterVille));
        }

        private void SupprimerVille(object sender, RoutedEventArgs e)
        {
            Town selection = (Town)lvVilles.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la ville {selection.NameTown} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.RemoveTown(selection); }, nameof(SupprimerVille));
                }
            }
        }
    }
}
