using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using NoteManager.ServiceReference1;
using System.Threading.Tasks;

namespace NoteManager
{
    class SeekerViewModel : INotifyPropertyChanged
    {
        ////////////////
        // Constructor
        ////////////////

        public SeekerViewModel()
        {
            this.initCommand();
            this.ActionSeek = false;
            WindowManager.SeekerViewModel = this;
        }


        //////////
        // Fields
        //////////

        public event PropertyChangedEventHandler PropertyChanged;

        private String _textToSeek;


        ///////////////
        // Properties
        ///////////////


        //
        // Commands for menu item Rechercher.
        //

        public ICommand Seek { get; private set; }

        public String TextToSeek
        {
            get { return _textToSeek; }
            set
            {
                _textToSeek = value;
                OnPropertyChanged("TextToSeek");
            }
        }

        public String TitleListNotes { get; set; }
        public String NameActionButtonListNotes { get; set; }
        public Boolean ActionSeek { get; set; }
        public UsersManager User { get; set; }
        public NotesNote[] listnotes { get; set; }


        /////////////
        // Methods
        /////////////

        private void OnPropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void initCommand()
        {
            this.Seek = new RelayCommand(seek);
        }

        private void seek()
        {
            if (this.TextToSeek != null && this.TextToSeek != "")
            {

                if (WindowManager.ListNotesUser.user != null)
                {
                    try
                    {
                        int nbNote;
                        Service1Client service = new Service1Client();
                        if (service != null)
                        {
                            nbNote = service.noteSearch(WindowManager.ListNotesUser.user.IdUser, this.TextToSeek).Length;
                            this.listnotes = new NotesNote[nbNote];
                            this.listnotes = service.noteSearch(WindowManager.ListNotesUser.user.IdUser, this.TextToSeek);
                            this.TitleListNotes = "Recherche dans les titres et dans les notes";
                            this.TextToSeek = "";
                            this.ActionSeek = true;
                            WindowManager.SeekerViewModel = this;
                            WindowManager.MainViewModel.createAndShowListNoteUserSeek();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                showErrSeekMsg("Vous n'avez entré ni texte ni note à rechercher !", "Aucune Recherche");
            }
        }

        private void showErrSeekMsg(String msg, String title)
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
