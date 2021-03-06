﻿using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AnnonceBDD
{
   public class Category : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private string cTitle;
        public string Title
        {
            get => cTitle;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException($"{nameof(Title)} : La catégorie doit avoir un titre (valeur NULL ou chaine vide).");
                }
                cTitle = value;
            }
        }
        private string cDescription;
        public string Description
        {
            get => cDescription;
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException($"{nameof(Description)} : La catégorie doit avoir une description (valeur NULL ou chaine vide).");
                }
                cDescription = value;
            }
        }
        private string cAvatar;
        public string Avatar
        {
            get => cAvatar;
            set
            {
                if (value == null || value == "") 
                { 
                    throw new ArgumentNullException($"{nameof(Avatar)} : Une image doit être assignée à la catégorie (valeur NULL ou chaine vide).");
                }
                cAvatar = value;
            }            
        }                      
        public ObservableCollection<Advert> Adverts { get; set; } = new ObservableCollection<Advert>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
