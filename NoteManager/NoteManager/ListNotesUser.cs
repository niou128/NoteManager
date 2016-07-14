using NoteManager.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace NoteManager
{
    class ListNotesUser
    {
        ////////////////////////
        // Fields & Properties
        ////////////////////////

        # region Fields & Properties

        public ListNotes ListNotesView { get; set; }
        public Seeker search { get; set; }
        public NotesNote NoteUser { get; set; }
        public UsersManager user { get; set; }
        public List<NotesNote> NotesUser { get; set; }
        public NotesNote[] listnotes { get; set; }
        public Boolean IsEmptyListNote { get; set; }
        public ListNotesFound ListNotesFound { get; set; }

        # endregion Fields & Properties


        ////////////////
        // Constructor
        ////////////////

        public ListNotesUser(UsersManager user)
        {
            this.user = user;
            this.IsEmptyListNote = true;
        }

        ////////////
        // Methods
        ////////////

        # region Methods

        # region make list of notes

        /// <summary>
        /// Make a list of the notes which belong to the current user.
        /// </summary>
        public void makeAndShowListCurrentUser()
        {
            this.getListNotesUser();
            this.setListNotesUser();
        }

        /// <summary>
        /// Make a list of the notes which elements were found after a research.
        /// </summary>
        public void makeAndShowListNotesResearched()
        {
            this.setListNotesUserSearch();
        }


        /// <summary>
        /// show the search view
        /// </summary>
        public void showSearch()
        {
            this.search = new Seeker();
            WindowManager.ListNotesUser = this;
            this.search.ShowDialog();
        }

        /// <summary>
        /// Get all notes from a user throw the web service
        /// </summary>
        public void getListNotesUser()
        {
            int nbNote;
            try
            {
                ServiceReference1.Service1Client services = new ServiceReference1.Service1Client();
                nbNote = services.noteGetAll(this.user.IdUser).Length;
                if (nbNote == 0)
                    this.IsEmptyListNote = true;
                else
                {
                    this.listnotes = new NotesNote[nbNote];
                    this.listnotes = services.noteGetAll(this.user.IdUser);
                    this.IsEmptyListNote = false;
                }
            }
            catch { }
        }

        /// <summary>
        /// Fill a list of the notes belonging to the user.
        /// </summary>
        public void setListNotesUser()
        {
            if ((this.ListNotesFound = new ListNotesFound()) != null)
            {
                if ((this.ListNotesFound.ListNoteFound = new List<KeyValuePair<long, String>>()) != null)
                {
                    if (WindowManager.SeekerViewModel != null && WindowManager.SeekerViewModel.ActionSeek)
                        this.listnotes = WindowManager.ListNotesUser.listnotes;
                    if (this.listnotes.Length > 0)
                    {
                        foreach (NotesNote note in this.listnotes)
                        {

                            this.ListNotesFound.ListNoteFound.Add(new KeyValuePair<long, String>(note.id, note.title));
                        }
                        if (this.ListNotesFound.ListNoteFound.Count() > 0)
                        {
                            this.IsEmptyListNote = false;
                        }
                        else
                        {
                            this.IsEmptyListNote = true;
                        }
                    }
                    else
                    {
                        this.IsEmptyListNote = true;
                    }
                }
            }
        }

        /// <summary>
        /// Lists the user notes matching the search
        /// </summary>
        public void setListNotesUserSearch()
        {
            if ((this.ListNotesFound = new ListNotesFound()) != null)
            {
                if ((this.ListNotesFound.ListNoteFound = new List<KeyValuePair<long, String>>()) != null)
                {
                    this.listnotes = WindowManager.SeekerViewModel.listnotes;
                    if (WindowManager.SeekerViewModel.listnotes.Length > 0)
                    {
                        foreach (NotesNote note in WindowManager.SeekerViewModel.listnotes)
                        {

                            this.ListNotesFound.ListNoteFound.Add(new KeyValuePair<long, String>(note.id, note.title));
                        }
                        if (this.ListNotesFound.ListNoteFound.Count() > 0)
                        {
                            this.IsEmptyListNote = false;
                        }
                        else
                        {
                            this.IsEmptyListNote = true;
                        }
                    }
                    else
                    {
                        this.IsEmptyListNote = true;
                    }
                }
            }
        }

        # endregion make list of notes

        # region show list user notes

        /// <summary>
        /// Show user notes list
        /// </summary>
        public void showListOwnerNote()
        {
            if (this.IsEmptyListNote)
            {
                MessageBox.Show(this.user.NameUser + " n'a pas de note(s) sauvegardée(s) ! ",
                       "Pas de notes utilisateur",
                       MessageBoxButton.OK,
                       icon: MessageBoxImage.Error);
            }
            else
            {
                if ((this.ListNotesView = new ListNotes()) != null)
                {
                    WindowManager.ListNotesUser = this;
                    this.ListNotesView.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Close the that contain webService's result
        /// </summary>
        public void closeListNotes()
        {
            this.ListNotesView.Close();
        }

        # endregion show list user notes

        # endregion Methods
    }
}
