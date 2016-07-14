using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private static Model.DatabaseEntities _db = new Model.DatabaseEntities();

        public string GetData(string value)
        {
            NotesNote.getList(_db.notes_notes.Where(n => n.id_user == 1).ToList());
            return string.Format("You entered: {0}", value);
        }

        public UsersUser login(String username, String password)
        {
            try
            { 
                string password_md5 = Model.Cryptography.getMd5Hash(MD5.Create(), password);
                var d = _db.users_users.Where(u => u.login == username && u.password == password_md5).SingleOrDefault();
                if (d != null)
                {
                     return new UsersUser(d);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean subscribeUser(String login, String password)
        {
            try
            {
                //If user exists
                var d = _db.users_users.Where(u => u.login == login).SingleOrDefault();
                if (d != null)
                {
                    return false;
                }

                Service.Model.UsersUser user = new Model.UsersUser();
                user.login = login;
                user.password = Model.Cryptography.getMd5Hash(MD5.Create(), password);

                _db.users_users.Add(user);
                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                
            }
            return false;
        }

        public List<NotesNote> noteGetAll(int id_user)
        {
            try
            {
                return NotesNote.getList(_db.notes_notes.Where(n => n.id_user == id_user).ToList());
            }
            catch (Exception) {
                return new List<NotesNote>();
            }
        }

        public List<NotesNote> noteSearch(int id_user, string text)
        {
             try
            {
                return NotesNote.getList(_db.notes_notes
                    .Where(n => n.id_user == id_user)
                    .Where(n => n.title.Contains(text) || n.content.Contains(text))
                    .OrderByDescending(n => n.date_update)
                    .ToList()
                    );
            }
            catch (Exception) {
                return new List<NotesNote>();
            }
        }

        public NotesNote noteGetSingle(int id_user, int id_note)
        {
            try
            {
                return new NotesNote(_db.notes_notes.Where(n => n.id_user == id_user && n.Id == id_note).Single());
            }
            catch (Exception) {
                return null;
            }
            
        }

        public int noteCreate(int id_user, NotesNote note)
        {
            try
            {
                Service.Model.NotesNote note_to_add = note.convertToModel();
                note_to_add.id_user = id_user;
                note_to_add.date_creation = DateTime.Now;
                note_to_add.date_update = null;
                _db.notes_notes.Add(note_to_add);
                _db.SaveChanges();

                _db.Entry(note_to_add).GetDatabaseValues();
                int id = note_to_add.Id;
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public Boolean noteUpdate(int id_user, NotesNote note_updated)
        {
            try
            {
                if (note_updated.id_user != id_user)
                {
                    throw new Exception("Cette note ne vous appartient pas.");
                }
                Service.Model.NotesNote original = _db.notes_notes.Where(n => n.id_user == id_user && n.Id == note_updated.id).Single();
                if (original == null)
                {
                    throw new Exception("Impossible de récupérer l'original");
                }
                note_updated.date_creation = original.date_creation;
                note_updated.date_update = DateTime.Now;
                _db.Entry(original).CurrentValues.SetValues(note_updated.convertToModel());
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool noteDelete(int id_user, int id_note)
        {
            try
            {
                Service.Model.NotesNote original = _db.notes_notes.Where(n => n.id_user == id_user && n.Id == id_note).Single();
                if (original.id_user != id_user)
                {
                    throw new Exception("Cette note ne vous appartient pas.");
                }
                if (original == null)
                {
                    throw new Exception("Impossible de récupérer l'original");
                }
                _db.notes_notes.Attach(original);
                _db.notes_notes.Remove(original);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
