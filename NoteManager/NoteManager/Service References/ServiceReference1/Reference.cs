﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoteManager.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsersUser", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class UsersUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string loginField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login {
            get {
                return this.loginField;
            }
            set {
                if ((object.ReferenceEquals(this.loginField, value) != true)) {
                    this.loginField = value;
                    this.RaisePropertyChanged("login");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NotesNote", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class NotesNote : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime date_creationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> date_updateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int id_userField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string titleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string content {
            get {
                return this.contentField;
            }
            set {
                if ((object.ReferenceEquals(this.contentField, value) != true)) {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date_creation {
            get {
                return this.date_creationField;
            }
            set {
                if ((this.date_creationField.Equals(value) != true)) {
                    this.date_creationField = value;
                    this.RaisePropertyChanged("date_creation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> date_update {
            get {
                return this.date_updateField;
            }
            set {
                if ((this.date_updateField.Equals(value) != true)) {
                    this.date_updateField = value;
                    this.RaisePropertyChanged("date_update");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id_user {
            get {
                return this.id_userField;
            }
            set {
                if ((this.id_userField.Equals(value) != true)) {
                    this.id_userField = value;
                    this.RaisePropertyChanged("id_user");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                if ((object.ReferenceEquals(this.titleField, value) != true)) {
                    this.titleField = value;
                    this.RaisePropertyChanged("title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/login", ReplyAction="http://tempuri.org/IService1/loginResponse")]
        NoteManager.ServiceReference1.UsersUser login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/login", ReplyAction="http://tempuri.org/IService1/loginResponse")]
        System.Threading.Tasks.Task<NoteManager.ServiceReference1.UsersUser> loginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/subscribeUser", ReplyAction="http://tempuri.org/IService1/subscribeUserResponse")]
        bool subscribeUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/subscribeUser", ReplyAction="http://tempuri.org/IService1/subscribeUserResponse")]
        System.Threading.Tasks.Task<bool> subscribeUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteGetAll", ReplyAction="http://tempuri.org/IService1/noteGetAllResponse")]
        NoteManager.ServiceReference1.NotesNote[] noteGetAll(int id_user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteGetAll", ReplyAction="http://tempuri.org/IService1/noteGetAllResponse")]
        System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote[]> noteGetAllAsync(int id_user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteSearch", ReplyAction="http://tempuri.org/IService1/noteSearchResponse")]
        NoteManager.ServiceReference1.NotesNote[] noteSearch(int id_user, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteSearch", ReplyAction="http://tempuri.org/IService1/noteSearchResponse")]
        System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote[]> noteSearchAsync(int id_user, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteGetSingle", ReplyAction="http://tempuri.org/IService1/noteGetSingleResponse")]
        NoteManager.ServiceReference1.NotesNote noteGetSingle(int id_user, int id_note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteGetSingle", ReplyAction="http://tempuri.org/IService1/noteGetSingleResponse")]
        System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote> noteGetSingleAsync(int id_user, int id_note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteCreate", ReplyAction="http://tempuri.org/IService1/noteCreateResponse")]
        int noteCreate(int id_user, NoteManager.ServiceReference1.NotesNote note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteCreate", ReplyAction="http://tempuri.org/IService1/noteCreateResponse")]
        System.Threading.Tasks.Task<int> noteCreateAsync(int id_user, NoteManager.ServiceReference1.NotesNote note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteUpdate", ReplyAction="http://tempuri.org/IService1/noteUpdateResponse")]
        bool noteUpdate(int id_user, NoteManager.ServiceReference1.NotesNote note_updated);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteUpdate", ReplyAction="http://tempuri.org/IService1/noteUpdateResponse")]
        System.Threading.Tasks.Task<bool> noteUpdateAsync(int id_user, NoteManager.ServiceReference1.NotesNote note_updated);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteDelete", ReplyAction="http://tempuri.org/IService1/noteDeleteResponse")]
        bool noteDelete(int id_user, int id_note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/noteDelete", ReplyAction="http://tempuri.org/IService1/noteDeleteResponse")]
        System.Threading.Tasks.Task<bool> noteDeleteAsync(int id_user, int id_note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : NoteManager.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<NoteManager.ServiceReference1.IService1>, NoteManager.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NoteManager.ServiceReference1.UsersUser login(string username, string password) {
            return base.Channel.login(username, password);
        }
        
        public System.Threading.Tasks.Task<NoteManager.ServiceReference1.UsersUser> loginAsync(string username, string password) {
            return base.Channel.loginAsync(username, password);
        }
        
        public bool subscribeUser(string login, string password) {
            return base.Channel.subscribeUser(login, password);
        }
        
        public System.Threading.Tasks.Task<bool> subscribeUserAsync(string login, string password) {
            return base.Channel.subscribeUserAsync(login, password);
        }
        
        public NoteManager.ServiceReference1.NotesNote[] noteGetAll(int id_user) {
            return base.Channel.noteGetAll(id_user);
        }
        
        public System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote[]> noteGetAllAsync(int id_user) {
            return base.Channel.noteGetAllAsync(id_user);
        }
        
        public NoteManager.ServiceReference1.NotesNote[] noteSearch(int id_user, string text) {
            return base.Channel.noteSearch(id_user, text);
        }
        
        public System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote[]> noteSearchAsync(int id_user, string text) {
            return base.Channel.noteSearchAsync(id_user, text);
        }
        
        public NoteManager.ServiceReference1.NotesNote noteGetSingle(int id_user, int id_note) {
            return base.Channel.noteGetSingle(id_user, id_note);
        }
        
        public System.Threading.Tasks.Task<NoteManager.ServiceReference1.NotesNote> noteGetSingleAsync(int id_user, int id_note) {
            return base.Channel.noteGetSingleAsync(id_user, id_note);
        }
        
        public int noteCreate(int id_user, NoteManager.ServiceReference1.NotesNote note) {
            return base.Channel.noteCreate(id_user, note);
        }
        
        public System.Threading.Tasks.Task<int> noteCreateAsync(int id_user, NoteManager.ServiceReference1.NotesNote note) {
            return base.Channel.noteCreateAsync(id_user, note);
        }
        
        public bool noteUpdate(int id_user, NoteManager.ServiceReference1.NotesNote note_updated) {
            return base.Channel.noteUpdate(id_user, note_updated);
        }
        
        public System.Threading.Tasks.Task<bool> noteUpdateAsync(int id_user, NoteManager.ServiceReference1.NotesNote note_updated) {
            return base.Channel.noteUpdateAsync(id_user, note_updated);
        }
        
        public bool noteDelete(int id_user, int id_note) {
            return base.Channel.noteDelete(id_user, id_note);
        }
        
        public System.Threading.Tasks.Task<bool> noteDeleteAsync(int id_user, int id_note) {
            return base.Channel.noteDeleteAsync(id_user, id_note);
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
    }
}
