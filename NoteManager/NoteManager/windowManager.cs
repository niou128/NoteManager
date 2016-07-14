using System;

namespace NoteManager
{
    static class WindowManager
    {
        static private LoginViewModel   _loginViewModel;
        static private MainViewModel    _mainViewModel;
        static private Boolean          _isConnected;
        static private NoteNameViewModel _noteNameViewModel;
        static private ListNotesViewModel _listNotesViewModel;
        static private ListNotesUser _listNotesUser;
        static private SeekerViewModel _seekerViewModel;

        public static MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set
            {
                _mainViewModel = value;
                if (_mainViewModel.VisibilityInscriptionConnection)
                {
                    if (WindowManager.LoginViewModel != null)
                    {
                        WindowManager.LoginViewModel.IsValidConnection = false;
                        WindowManager.LoginViewModel.initBoxLogin();
                    }
                }
            }
        }

        public static LoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set
            {
                _loginViewModel = value;
                if (_loginViewModel.EventSignIn && _loginViewModel.IsValidConnection)
                {
                    WindowManager.IsConnected = _loginViewModel.IsValidConnection;
                }
            }
        }

        public static Boolean IsConnected
        {
            get { return WindowManager._isConnected; }
            set
            {
                WindowManager._isConnected = value;
                if (WindowManager._isConnected)
                {
                    WindowManager.MainViewModel.hideBoxLogin();
                    WindowManager.MainViewModel.CurrentUser = WindowManager.LoginViewModel.ResultSignIn;
                    WindowManager.MainViewModel.createSession();
                    WindowManager.MainViewModel.newNote();
                    WindowManager.MainViewModel.showNote();
                }
            }
        }

        public static NoteNameViewModel NoteNameViewModel
        {
            get { return WindowManager._noteNameViewModel; }
            set
            {
                WindowManager._noteNameViewModel = value;
                if (WindowManager.NoteNameViewModel != null
                    && WindowManager.NoteNameViewModel.IsValidate == true
                    && WindowManager.NoteNameViewModel.ContentNoteName != null)
                {
                    WindowManager.MainViewModel.TitleNote = WindowManager.NoteNameViewModel.ContentNoteName;
                    WindowManager.MainViewModel.closeViewNoteName();
                }
            }
        }

        public static ListNotesViewModel ListNotesViewModel
        {
            get { return WindowManager._listNotesViewModel; }
            set
            {
                bool isSearch = WindowManager.SeekerViewModel == null ? false : WindowManager.SeekerViewModel.ActionSeek;
                WindowManager._listNotesViewModel = value;
                if (WindowManager.ListNotesUser != null
                    && !WindowManager._listNotesViewModel.IsValidateChoice && !isSearch)
                {
                    WindowManager.ListNotesUser.closeListNotes();
                }
                else if (WindowManager._listNotesViewModel.IsValidateChoice)
                {
                    WindowManager.MainViewModel.ChoosenNote = WindowManager._listNotesViewModel.ChoosenNote;
                    WindowManager.ListNotesUser.closeListNotes();

                    if (!WindowManager.MainViewModel.IsActionDelete)
                    {
                        WindowManager.MainViewModel.loadNote();
                    }
                }
            }
        }

        public static ListNotesUser ListNotesUser
        {
            get { return WindowManager._listNotesUser; }
            set
            {
                WindowManager._listNotesUser = value;
                if (!_listNotesUser.IsEmptyListNote
                    && WindowManager.ListNotesViewModel != null)
                {
                    WindowManager.ListNotesViewModel.TitleList = _mainViewModel.TitleListNotes;
                    WindowManager.ListNotesViewModel.NameButtonAction = _mainViewModel.NameActionButtonListNotes;
                    WindowManager.ListNotesViewModel.NotesFound = _listNotesUser.ListNotesFound.ListNoteFound;
                }
            }
        }

        public static SeekerViewModel SeekerViewModel
        {
            get { return WindowManager._seekerViewModel; }
            set
            {
                WindowManager._seekerViewModel = value;
                if (_seekerViewModel.User != null
                    && _seekerViewModel.ActionSeek == true)
                {
                    WindowManager.MainViewModel.User = _seekerViewModel.User;
                    WindowManager.MainViewModel.TitleListNotes = _seekerViewModel.TitleListNotes;
                    WindowManager.MainViewModel.NameActionButtonListNotes = _seekerViewModel.NameActionButtonListNotes;
                    WindowManager.MainViewModel.createAndShowListNoteUserSeek();
                }
            }
        }
    }
}
