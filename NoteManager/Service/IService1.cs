using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        UsersUser login(String username, String password);

        [OperationContract]
        Boolean subscribeUser(String login, String password);

        [OperationContract]
        List<NotesNote> noteGetAll(int id_user);

        [OperationContract]
        List<NotesNote> noteSearch(int id_user, String text);

        [OperationContract]
        NotesNote noteGetSingle(int id_user, int id_note);

        [OperationContract]
        int noteCreate(int id_user, NotesNote note);

        [OperationContract]
        Boolean noteUpdate(int id_user, NotesNote note_updated);

        [OperationContract]
        Boolean noteDelete(int id_user, int id_note);

        [OperationContract]
        string GetData(string value);

    }

    [DataContract]
    public class NotesNote
    {
        [DataMember]
        public int id;
        [DataMember]
        public int id_user;
        [DataMember]
        public string title;
        [DataMember]
        public string content;
        [DataMember]
        public DateTime date_creation;
        [DataMember]
        public DateTime? date_update;

        public NotesNote(Service.Model.NotesNote note)
        {
            id = note.Id;
            id_user = note.id_user;
            title = note.title;
            content = note.content;
            date_creation = note.date_creation;
            date_update = note.date_update;
        }

        public static List<NotesNote> getList(List<Service.Model.NotesNote> notes)
        {
            List<NotesNote> notes_to_return = new List<NotesNote>();

            foreach (var note in notes)
            {
                notes_to_return.Add(new NotesNote(note));
            }

            return notes_to_return;
        }

        public Service.Model.NotesNote convertToModel()
        {
            Service.Model.NotesNote new_note = new Service.Model.NotesNote();

            new_note.Id = id;
            new_note.id_user = id_user;
            new_note.title = title;
            new_note.content = content;
            new_note.date_creation = date_creation;
            new_note.date_update = date_update;

            return new_note;
        }
    }

    [DataContract]
    public class UsersUser
    {
        [DataMember]
        public int id;
        [DataMember]
        public string login;

        public UsersUser(Service.Model.UsersUser user)
        {
            id = user.id;
            login = user.login;
        }

        public static List<UsersUser> getList(List<Service.Model.UsersUser> users)
        {
            List<UsersUser> users_to_return = new List<UsersUser>();

            foreach (var user in users)
            {
                users_to_return.Add(new UsersUser(user));
            }

            return users_to_return;
        }
    }
}
