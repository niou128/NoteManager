using System;
using NoteManager.ServiceReference1;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NoteManager
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.initCommand();
            this.NameApplication = "NoteManager";
            this.TitleWindow = this._defaultTitleNote + " - " + this.NameApplication;
            this.IsMenuEnabled = false;
            this.showBoxLogin();
            WindowManager.MainViewModel = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private String _titleWindow;
        private String _nameApplication;
        private String _defaultTitleNote = "sans nom";
        private Boolean _isMenuEnabled;
        private Boolean _visibilityNote;
        private Boolean _visibilityInscriptionConnection;
        private UsersUser _currentUser;
        private UsersManager _user;
        private String _titleNote = null;
        private Boolean _isDefaultTitleNote = true;
        private String _contentNote;
        private NotesNote _note;
        private NoteName _noteNameView;
        private Boolean _isRecorded = false;
        private Boolean _isDefaultTextNote;
        private int _idNote;
        private String _choosenNote;
        private Boolean _isDeleteEnabled;
        private Boolean _isSaveAsEnabled;


        public ICommand Save { get; private set; }
        public ICommand SaveAs { get; private set; }
        public ICommand Open { get; private set; }
        public ICommand DeleteNote { get; private set; }

        public ICommand Quit { get; private set; }
        public ICommand Copy { get; private set; }
        public ICommand Paste { get; private set; }

        public ICommand ShowNote { get; private set; }
        public ICommand HideNote { get; private set; }
        public ICommand ClearTextBoxNote { get; private set; }

        public ICommand ShowBoxLogin { get; private set; }
        public ICommand HideBoxLogin { get; private set; }
        public ICommand LogOut { get; private set; }

        public ICommand search { get; private set; }


        private void OnPropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public Boolean IsActionDelete { get; set; }
        public ListNotesUser ListNotesUser { get; set; }

        public String TitleListNotes { get; set; }
        public String NameActionButtonListNotes { get; set; }

        #region getter/setter
        public String TitleWindow
        {
            get { return _titleWindow; }
            set
            {
                _titleWindow = value;
                OnPropertyChanged("_titleWindow");
            }
        }

        public String NameApplication
        {
            get { return _nameApplication; }
            set { _nameApplication = value; }
        }

        public Boolean IsMenuEnabled
        {
            get { return _isMenuEnabled; }
            set
            {
                _isMenuEnabled = value;
                OnPropertyChanged("IsMenuEnabled");
            }
        }

        public Boolean VisibilityNote
        {
            get { return _visibilityNote; }
            set
            {
                _visibilityNote = value;
                OnPropertyChanged("VisibilityNote");
            }
        }

        public Boolean IsSaveAsEnabled
        {
            get { return _isSaveAsEnabled; }
            set
            {
                _isSaveAsEnabled = value;
                OnPropertyChanged("IsSaveAsEnabled");
            }
        }

        public Boolean IsDeleteEnabled
        {
            get { return _isDeleteEnabled; }
            set
            {
                _isDeleteEnabled = value;
                OnPropertyChanged("IsDeleteEnabled");
            }
        }

        public Boolean VisibilityInscriptionConnection
        {
            get { return _visibilityInscriptionConnection; }
            set
            {
                _visibilityInscriptionConnection = value;
                OnPropertyChanged("VisibilityInscriptionConnection");
            }
        }

        public UsersManager User
        {
            get { return _user; }
            set { _user = value; }
        }

        public UsersUser CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public String TitleNote
        {
            get { return _titleNote; }
            set { _titleNote = value; }
        }

        public Boolean IsDefaultTitleNote
        {
            get { return _isDefaultTitleNote; }
            set { _isDefaultTitleNote = value; }
        }

        public NoteName NoteNameView
        {
            get { return _noteNameView; }
            set { _noteNameView = value; }
        }

        public int IdNote
        {
            get { return _idNote; }
            set { _idNote = value; }
        }

        public NotesNote Note
        {
            get { return _note; }
            set { _note = value; }
        }
        public Boolean IsRecorded
        {
            get { return _isRecorded; }
            set
            {
                _isRecorded = value;
                modifTitleWindow(_isRecorded);
            }
        }

        public Boolean IsDefaultTextNote
        {
            get { return _isDefaultTextNote; }
            set { _isDefaultTextNote = value; }
        }

        public String ChoosenNote
        {
            get { return _choosenNote; }
            set
            {
                _choosenNote = value;
            }
        }

        public NotesNote[] listnotes { get; set; }

        #endregion getter/setter

        public void showNote()
        {
            this.IsMenuEnabled = true;
            this.VisibilityNote = true;
        }

        public void hideNote()
        {
            this.VisibilityNote = false;
        }

        public void showBoxLogin()
        {
            this.VisibilityInscriptionConnection = true;
            WindowManager.MainViewModel = this;
        }

        public void hideBoxLogin()
        {
            this.VisibilityInscriptionConnection = false;
        }



        private void initCommand()
        {
            this.Quit = new RelayCommand(quit);
            this.Copy = new RelayCommand(copy);
            this.Paste = new RelayCommand(paste);
            this.LogOut = new RelayCommand(logOut);
            this.Save = new RelayCommand(save);
            this.SaveAs = new RelayCommand(saveAs);
            this.Open = new RelayCommand(openNote);
            this.DeleteNote = new RelayCommand(deleteNote);
            this.search = new RelayCommand(searchNote);
        }

        /// <summary>
        /// ask if you really want to quit and quit if you anwser yes
        /// </summary>
        private void quit()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            Application.Current.Shutdown();
        }

        private void copy()
        {
            Clipboard.SetText(this.ContentNote);
        }

        /// <summary>
        /// Paste the clipboard in the current note
        /// </summary>
        private void paste()
        {
            this.ContentNote += Clipboard.GetText();
        }

        public void createSession()
        {
            this.User = new UsersManager();
            if (this.User != null)
            {
                this.User.NameUser = this.CurrentUser.login;
                this.User.IsLogged = true;
                this.User.IdUser = this.CurrentUser.id;
                //this.ViewUserNameLogged = this.User.NameUser;
            }
        }

        /// <summary>
        /// logout a user
        /// </summary>
        private void logOut()
        {
            this.IsMenuEnabled = false;
            this.User = null;
            this.TitleWindow = this._defaultTitleNote + " - " + this.NameApplication;
            this.showBoxLogin();
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        public void newNote()
        {
            this.TitleNote = null;
            this.TitleWindow = this._defaultTitleNote + " - " + this.NameApplication;
            this.IsDefaultTitleNote = true;
            this.IsSaveAsEnabled = false;
            this.IsDeleteEnabled = true;
            initContentNote();
        }


        /// <summary>
        ///  Save the note and set a title if it's a new note
        /// </summary>
        private void save()
        {
            if (this.TitleNote == null)
            {
                this.newTitleNote();
            }
            this.record();
            modifTitleWindow(this.IsRecorded);
            this.IsSaveAsEnabled = true;
            this.IsDeleteEnabled = false;
        }

        /// <summary>
        /// Save the current note as a new note
        /// </summary>
        private void saveAs()
        {
            this.newTitleNote();
            this.Note = null;
            this.record();
            modifTitleWindow(this.IsRecorded);
            this.IsSaveAsEnabled = true;
            this.IsDeleteEnabled = true;
        }

        private void record()
        {
            if (recordNote() == true)
            {
                this.TitleWindow = this.TitleNote + " - " + this.NameApplication;
                this.IsDefaultTitleNote = false;
            }
            else
            {
                MessageBox.Show("La note "
                   + this.TitleNote
                   + " n'a pas été enregistrée.",
                   "Erreur d'enregistrement",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Ask for the title of the current note
        /// </summary>
        private void newTitleNote()
        {
            NoteNameView = new NoteName();
            NoteNameView.ShowDialog();
        }

        private void initContentNote()
        {
            this.ContentNote = null;
            this.ContentNote = "Nouvelle note.";
        }

        public String ContentNote
        {
            get { return _contentNote; }
            set
            {
                _contentNote = value;
                OnPropertyChanged("ContentNote");
            }
        }

        /// <summary>
        /// Save the note in db
        /// </summary>
        /// <returns></returns>
        private Boolean recordNote()
        {
            if (this.TitleNote != null)
            {
                if (this.Note == null)
                {
                    this.Note = new NotesNote();
                    this.Note.title = this.TitleNote;
                    this.Note.content = this.ContentNote;
                    try
                    {
                        ServiceReference1.Service1Client noteToSave = new ServiceReference1.Service1Client();
                        this.IdNote = noteToSave.noteCreate(this.User.IdUser, this.Note);
                        this.IsRecorded = this.IdNote != -1 ? true : false;
                    }
                    catch { }
                    return (this.IsRecorded);

                }
                else
                {
                    this.Note.content = this.ContentNote;
                    this.Note.id_user = this.User.IdUser;
                    this.Note.id = this.IdNote;
                    try
                    {
                        ServiceReference1.Service1Client noteToSave = new ServiceReference1.Service1Client();
                        this.IsRecorded = noteToSave.noteUpdate(this.User.IdUser, this.Note);
                    }
                    catch { }
                    return (this.IsRecorded);
                }
            }
            return (false);
        }

        /// <summary>
        /// change Title of the window 
        /// </summary>
        /// <param name="isRecorded"></param>
        private void modifTitleWindow(bool isRecorded)
        {
            if (!isRecorded && !this.IsDefaultTextNote)
            {
                if (this.IsDefaultTitleNote)
                {
                    this.TitleWindow = this._defaultTitleNote + "*" + " - " + this.NameApplication;
                }
                else if (!this.IsDefaultTitleNote)
                {
                    this.TitleWindow = this.TitleNote + "*" + " - " + this.NameApplication;
                }
            }
            else if (isRecorded)
            {
                if (this.IsDefaultTitleNote)
                {
                    this.TitleWindow = this._defaultTitleNote + " - " + this.NameApplication;
                }
                else if (!this.IsDefaultTitleNote)
                {
                    this.TitleWindow = this.TitleNote + " - " + this.NameApplication;
                }
            }
        }

        /// <summary>
        /// Close the box that ask for note title
        /// </summary>
        public void closeViewNoteName()
        {
            NoteNameView.Close();
        }

        /// <summary>
        /// open a note from a list
        /// </summary>
        private void openNote()
        {
            //this.IsActionDelete = false;
            if (!this.IsRecorded)
            {
                MessageBoxResult resultWantRecord = showWantRecordNote();
                if (resultWantRecord == MessageBoxResult.Yes)
                {
                    save();
                }
                else if (resultWantRecord == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            this.TitleListNotes = "liste des notes de " + this.User.NameUser;
            this.NameActionButtonListNotes = "Ouvrir";
            if ((this.ListNotesUser = new ListNotesUser(this.User)) != null)
            {
                this.ListNotesUser.makeAndShowListCurrentUser();
                this.listnotes = this.ListNotesUser.listnotes;
                this.ListNotesUser.showListOwnerNote();
                this.ListNotesUser = null;
            }
        }

        /// <summary>
        /// Ask for save the current note
        /// </summary>
        /// <returns></returns>
        public MessageBoxResult showWantRecordNote()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous enregistrer les modifications de "
                + (this.TitleNote == null ? this._defaultTitleNote : this.TitleNote)
                + " ?",
                "Confirmation",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
            return (result);
        }

        public void loadNote()
        {
            if (this.ChoosenNote != null)
            {
                if (WindowManager.SeekerViewModel != null && WindowManager.SeekerViewModel.ActionSeek)
                    this.listnotes = WindowManager.ListNotesUser.listnotes;
                if (this.listnotes.Length > 0)
                {
                    foreach (NotesNote note in this.listnotes)
                    {
                        if (note.title == this.ChoosenNote)
                        {
                            ServiceReference1.Service1Client servicebdd = new ServiceReference1.Service1Client();
                            if (servicebdd != null)
                            {
                                this.Note = servicebdd.noteGetSingle(this.User.IdUser, note.id);
                                this.ContentNote = this.Note.content;
                                this.IdNote = note.id;
                                this.TitleNote = this.ChoosenNote;
                                this.TitleWindow = this.TitleNote + " - " + this.NameApplication;
                                this.IsDefaultTitleNote = false;
                                this.IsDefaultTextNote = false;
                                this.IsSaveAsEnabled = true;
                                this.IsDeleteEnabled = true;
                                break;
                            }
                        }
                    }
                }
                this.ChoosenNote = null;
            }
        }

        /// <summary>
        /// Delete a note
        /// </summary>
        private void deleteNote()
        {
            this.IsActionDelete = true;
            this.TitleListNotes = "liste des notes de " + this.User.NameUser;
            this.NameActionButtonListNotes = "Effacer";
            if ((this.ListNotesUser = new ListNotesUser(this.User)) != null)
            {
                this.ListNotesUser.makeAndShowListCurrentUser();
                this.listnotes = this.ListNotesUser.listnotes;
                this.ListNotesUser.showListOwnerNote();
                this.ListNotesUser = null;
                if (this.ChoosenNote != null)
                {
                    if (this.listnotes.Length > 0)
                    {
                        foreach (NotesNote note in this.listnotes)
                        {
                            if (note.title == this.ChoosenNote)
                            {
                                try
                                {
                                    Service1Client sessionUser = new Service1Client();
                                    if (sessionUser != null)
                                    {
                                        this.TitleNote = this.ChoosenNote;
                                        Boolean resultDeleteQuery = sessionUser.noteDelete(this.User.IdUser, note.id);
                                        break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    this.ChoosenNote = null;
                }
            }
        }

        /// <summary>
        /// Create list of note
        /// </summary>
        public void createAndShowListNoteUserSeek()
        {
            this.IsActionDelete = false;
            if ((this.ListNotesUser = new ListNotesUser(this.User)) != null)
            {
                this.ListNotesUser = this.ListNotesUser;
                this.ListNotesUser.makeAndShowListNotesResearched();
                this.NameActionButtonListNotes = "Ouvrir";
                this.ListNotesUser.showListOwnerNote();
                this.ListNotesUser = null;
            }
        }

        /// <summary>
        /// show the Search Box
        /// </summary>
        public void searchNote()
        {
            this.ListNotesUser = new ListNotesUser(this.User);
            this.ListNotesUser.showSearch();
        }
    }
}
