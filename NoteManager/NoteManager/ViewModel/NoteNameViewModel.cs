using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NoteManager
{
    class NoteNameViewModel : INotifyPropertyChanged
    {
        public NoteNameViewModel()
        {
            this.IsValidate = false;
            this.Validate = new RelayCommand(validate);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private String _contentNoteName;
        public String ContentNoteName
        {
            get { return _contentNoteName; }
            set
            {
                _contentNoteName = value;
                OnPropertyChanged("ContentNoteName");
            }
        }

        private Boolean _isValidate;

        public Boolean IsValidate
        {
            get { return _isValidate; }
            set { _isValidate = value; }
        }


        public ICommand Validate { get; private set; }

        private void validate()
        {
            this.IsValidate = true;
            if (this.ContentNoteName == null
                || this.ContentNoteName == "")
            {
                showErrorNameTitle("Vous n'avez entré aucun titre !");
                this.IsValidate = false;
                this.ContentNoteName = null;
            }
            else if (this.ContentNoteName != null
                && this.ContentNoteName.Trim() == "")
            {
                showErrorNameTitle("Le caractère 'espace' est interdit comme titre de note !");
                this.IsValidate = false;
                this.ContentNoteName = null;
            }
            else
            {
                this.IsValidate = true;
                WindowManager.NoteNameViewModel = this;
            }
        }

        private void showErrorNameTitle(String msg)
        {
            MessageBox.Show(
                      msg
                      + "\n\nVeuillez choisir un nom valide.",
                      "Erreur titre de note",
                      MessageBoxButton.OK,
                      icon: MessageBoxImage.Error);
        }
    }
}
