using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NoteManager
{
    class ListNotesViewModel : INotifyPropertyChanged
    {
        ////////////////
        // Constructor
        ////////////////

        public ListNotesViewModel()
        {
            this.IsValidateChoice = false;
            this.ValidateChoice = new RelayCommand(validateChoice);
            this.CancelChoice = new RelayCommand(cancelChoice);
            this.NotesFound = new List<KeyValuePair<long, String>>();
            this.TitlesNotesFound = new List<string>();
            WindowManager.ListNotesViewModel = this;
        }



        ///////////
        // Fields
        ///////////

        public event PropertyChangedEventHandler PropertyChanged;

        private List<KeyValuePair<long, String>> _notesFound;
        private String _titleList = "Liste";
        private String _nameButtonAction;
        private String _choosenNote;
        private List<String> _titlesNotesFound;



        ///////////////
        // Properties
        ///////////////

        public List<KeyValuePair<long, String>> NotesFound
        {
            get { return _notesFound; }
            set
            {
                _notesFound = value;
                setTitleNotesFound();
                OnPropertyChanged("NotesFound");
            }
        }

        public List<String> TitlesNotesFound
        {
            get { return _titlesNotesFound; }
            set
            {
                _titlesNotesFound = value;
                OnPropertyChanged("TitlesNotesFound");
            }
        }

        public ICommand ValidateChoice { get; private set; }
        public ICommand CancelChoice { get; private set; }
        public Boolean IsFromSeekerViewModel { get; set; }
        public Boolean IsFromMainViewModel { get; set; }
        public Boolean IsValidateChoice { get; set; }

        public String ChoosenNote
        {
            get { return _choosenNote; }
            set
            {
                _choosenNote = value;
            }
        }

        public String TitleList
        {
            get { return _titleList; }
            set
            {
                _titleList = value;
                OnPropertyChanged("TitleList");
            }
        }

        public String NameButtonAction
        {
            get { return _nameButtonAction; }
            set
            {
                _nameButtonAction = value;
                OnPropertyChanged("NameButtonAction");
            }
        }



        ////////////
        // Methods
        ////////////

        private void OnPropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void validateChoice()
        {
            this.IsValidateChoice = true;
            if (this.ChoosenNote != null)
            {
                WindowManager.ListNotesViewModel = this;
            }
            else
            {
                MessageBox.Show("Aucune note n'a été choisie ! ",
                           "Aucun choix",
                           MessageBoxButton.OK,
                           icon: MessageBoxImage.Error);
            }
        }

        private void cancelChoice()
        {
            this.IsValidateChoice = false;
            WindowManager.ListNotesViewModel = this;
        }

        private void setTitleNotesFound()
        {
            foreach (KeyValuePair<long, String> titleNote in NotesFound)
            {
                TitlesNotesFound.Add(titleNote.Value);
            }
        }
    }
}
