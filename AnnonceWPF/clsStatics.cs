using System;
using System.Windows;

namespace AnnonceWPF
{
    class Statics
    {
        public static void TryCatch(Action aAction, string aTitreMsgBox)
        {
            try
            {
                aAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, aTitreMsgBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
