using NoteManager.ServiceReference1;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NoteManager
{
    class LoginViewModel : INotifyPropertyChanged
    {

        public LoginViewModel()
        {
            this.initCommand();
            this.IsValidConnection = false;
            this.EventSignIn = false;
            this.ResultInscription = false;
            this.IsCheckFormOk = false;
            this.initBoxLogin();
            WindowManager.LoginViewModel = this;
        }


        # region fields

        public event PropertyChangedEventHandler PropertyChanged;

        private String _login;
        private String _pwd;
        private String _confPwd;
        private Boolean _inscriptionChecked;
        private Boolean _connectionChecked;
        private Boolean _visibilityConfirmationPswd;
        private String _btValidationName;
        private String _headerNameConnectionInscriton;
        private int _heightGrpBoxInscriptionConnection;
        private Boolean _visibilityLogin;
        private Boolean _visibilityPassword;
        private Boolean _visibilityBtValidation;
        private Thickness _btRadioConnectionMargin;
        private Thickness _btRadioInscriptionMargin;
        private Thickness _btValidationMargin;
        private Boolean _isValidConnection;

        # endregion fields



        public ICommand ShowFormConnection { get; private set; }
        public ICommand ShowFormInscription { get; private set; }
        public ICommand Validation { get; private set; }

        public Boolean IsInscription { get; set; }
        public String UserLogged { get; set; }
        public Boolean EventSignIn { get; set; }
        private Boolean IsCheckFormOk { get; set; }
        private Boolean ResultInscription { get; set; }
        public UsersUser ResultSignIn { get; set; }

        #region getter/setter
        public Boolean IsValidConnection
        {
            get { return _isValidConnection; }
            set
            {
                _isValidConnection = value;
                OnPropertyChanged("IsValidConnection");
            }
        }

        public Boolean InscriptionChecked
        {
            get { return _inscriptionChecked; }
            set
            {
                _inscriptionChecked = value;
                OnPropertyChanged("InscriptionChecked");
            }
        }

        public String Pwd
        {
            get { return _pwd; }
            set
            {
                _pwd = value;
                OnPropertyChanged("Pwd");
            }
        }

        public String ConfPwd
        {
            get { return _confPwd; }
            set
            {
                _confPwd = value;
                OnPropertyChanged("ConfPwd");
            }
        }

        public Boolean ConnectionChecked
        {
            get { return _connectionChecked; }
            set
            {
                _connectionChecked = value;
                OnPropertyChanged("ConnectionChecked");
            }
        }

        public String btValidationName
        {
            get { return _btValidationName; }
            set
            {
                _btValidationName = value;
                OnPropertyChanged("btValidationName");
            }
        }

        public Boolean VisibilityLogin
        {
            get { return _visibilityLogin; }
            set
            {

                _visibilityLogin = value;
                OnPropertyChanged("VisibilityLogin");
            }
        }

        public Boolean VisibilityPassword
        {
            get { return _visibilityPassword; }
            set
            {
                _visibilityPassword = value;
                OnPropertyChanged("VisibilityPassword");
            }
        }

        public Boolean VisibilityConfirmationPswd
        {
            get { return _visibilityConfirmationPswd; }
            set
            {
                _visibilityConfirmationPswd = value;
                OnPropertyChanged("VisibilityConfirmationPswd");
            }
        }

        public String Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public String HeaderNameConnectionInscriton
        {
            get { return _headerNameConnectionInscriton; }
            set
            {
                _headerNameConnectionInscriton = value;
                OnPropertyChanged("HeaderNameConnectionInscriton");
            }
        }

        public int HeightGrpBoxInscriptionConnection
        {
            get { return _heightGrpBoxInscriptionConnection; }
            set
            {
                _heightGrpBoxInscriptionConnection = value;
                OnPropertyChanged("HeightGrpBoxInscriptionConnection");
            }
        }

        public Boolean VisibilityBtValidation
        {
            get { return _visibilityBtValidation; }
            set
            {
                _visibilityBtValidation = value;
                OnPropertyChanged("VisibilityBtValidation");
            }
        }

        public Thickness BtRadioConnectionMargin
        {
            get { return _btRadioConnectionMargin; }
            set
            {
                _btRadioConnectionMargin = value;
                OnPropertyChanged("BtRadioConnectionMargin");
            }
        }

        public Thickness BtRadioInscriptionMargin
        {
            get { return this._btRadioInscriptionMargin; }
            set
            {
                _btRadioInscriptionMargin = value;
                OnPropertyChanged("BtRadioInscriptionMargin");
            }
        }

        public Thickness BtValidationMargin
        {
            get { return _btValidationMargin; }
            set
            {
                _btValidationMargin = value;
                OnPropertyChanged("BtValidationMargin");
            }
        }

        #endregion getter/setter

        #region Methods

        private void OnPropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        # region initialisation

        public void initCommand()
        {
            this.Validation = new RelayCommand(validation);
            this.ShowFormConnection = new RelayCommand(showFormConnection);
            this.ShowFormInscription = new RelayCommand(showFormInscription);
        }

        private void showFormConnection()
        {
            this.IsInscription = false;
            this.HeaderNameConnectionInscriton = "Connexion";
            this.btValidationName = "Connexion";
            this.VisibilityLogin = true;
            this.VisibilityPassword = true;
            this.VisibilityConfirmationPswd = false;
            this.VisibilityBtValidation = true;
            this.InscriptionChecked = false;
            this.ConnectionChecked = true;
            this.Login = null;
            this.Pwd = null;
            this.HeightGrpBoxInscriptionConnection = 245;
            this.BtValidationMargin = new Thickness(164, 150, 0, 0);
            this.BtRadioInscriptionMargin = new Thickness(125, 198, 0, 0);
            this.BtRadioConnectionMargin = new Thickness(220, 198, 0, 0);
            OnPropertyChanged("ConnectionChecked");
            OnPropertyChanged("Login");
            OnPropertyChanged("Pwd");
        }

        private void showFormInscription()
        {
            this.IsInscription = true;
            this.HeaderNameConnectionInscriton = "Inscription";
            this.btValidationName = "Inscription";
            this.Login = null;
            this.Pwd = null;
            this.ConfPwd = null;
            this.VisibilityLogin = true;
            this.VisibilityPassword = true;
            this.VisibilityConfirmationPswd = true;
            this.VisibilityBtValidation = true;
            this.ConnectionChecked = false;
            this.InscriptionChecked = true;
            this.HeightGrpBoxInscriptionConnection = 290;
            this.BtValidationMargin = new Thickness(164, 198, 0, 0);
            this.BtRadioInscriptionMargin = new Thickness(125, 240, 0, 0);
            this.BtRadioConnectionMargin = new Thickness(220, 240, 0, 0);
            OnPropertyChanged("InscriptionChecked");
            OnPropertyChanged("Login");
            OnPropertyChanged("Pwd");
            OnPropertyChanged("ConfPwd");
        }

        public void initBoxLogin()
        {
            this.BtRadioInscriptionMargin = new Thickness(125, 25, 0, 0);
            this.BtRadioConnectionMargin = new Thickness(220, 25, 0, 0);
            this.InscriptionChecked = false;
            this.ConnectionChecked = false;
            this.HeaderNameConnectionInscriton = "Inscription / Connexion";
            this.VisibilityConfirmationPswd = false;
            this.VisibilityBtValidation = false;
            this.VisibilityLogin = false;
            this.HeightGrpBoxInscriptionConnection = 80;
        }

        # endregion initialisation

        # region User subscription

        //
        // Inscription
        //
        public Boolean inscriptionToBase()
        {
            this.checkFormSubscription();
            if (this.IsCheckFormOk)
            {
                try
                {
                    Service1Client client = new Service1Client();
                    if (client != null)
                    {
                        bool resultSubscribe = client.subscribeUser(this.Login, this.Pwd);
                        this.checkSubscription(resultSubscribe);
                    }
                }
                catch
                {
                    this.showErrorSignIn(
                                    " Impossible de contacter le web service.",
                                    "Erreur inscription utilisateur");
                    this.ResultInscription = false;
                }
            }
            return (this.ResultInscription);
        }

        /// <summary>
        /// Check if datas are correct
        /// </summary>
        private void checkFormSubscription()
        {
            if (this.Login == null || this.Login == ""
               || this.Pwd == null || this.Pwd == ""
               || this.ConfPwd == null || this.ConfPwd == "")
            {
                this.showErrorSignIn(
                       "Tous les champs sont obligatoires !\n\nVeuillez les remplir.",
                       "Erreur inscription utilisateur");
                this.ResultInscription = false;
            }
            else if (this.Login != null && this.Login.Trim() == "")
            {
                this.showErrorSignIn(
                      "Le caractère 'espace' est interdit comme nom utilisateur !"
                      + "\n\nVeuillez choisir un autre nom !",
                      "Erreur inscription utilisateur");
                this.ResultInscription = false;
            }
            else if (this.Pwd != this.ConfPwd)
            {
                this.showErrorSignIn(
                       "Les mots de passe ne correspondent pas !\n\nVeuillez recommencer.",
                       "Erreur inscription utilisateur");
                this.ResultInscription = false;
            }
            else
            {
                this.IsCheckFormOk = true;
            }
        }

        private void checkSubscription(bool resultSubscribe)
        {
            if (resultSubscribe == true)
            {
                MessageBox.Show(
                                this.Login + " a bien été inscrit",
                                "Inscription utilisateur",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                ResultInscription = true;
            }
            else if (resultSubscribe == false)
            {
                this.showErrorSignIn(
                                  this.Login + " n'a pas été inscrit" +
                                  "\n\n Erreur de base de données.",
                                  "Erreur inscription utilisateur");
                ResultInscription = false;
            }
        }

        # endregion User subscription
        //
        // Procession action after click on buttion "Inscription" or "Connexion".
        //
        private void validation()
        {
            if (IsInscription)
            {
                if (this.inscriptionToBase())
                {
                    this.initBoxLogin();
                }
            }
            else if (!IsInscription)
            {
                this.EventSignIn = true;
                this.UserLogin();
            }
        }

        public void UserLogin()
        {
            try
            {
                Service1Client User = new Service1Client();
                if (User != null && ((ResultSignIn = new UsersUser()) != null))
                {
                    ResultSignIn = User.login(this.Login, this.Pwd);
                    if (!(this.IsValidConnection = ResultSignIn != null ? true : false))
                    {
                        this.showErrorSignIn(
                            "Authentification incorrecte."
                            + "\nVeuillez recommencer.",
                            "Erreur authentification utilisateur");
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("\n" + e.Message);
                this.showErrorSignIn("Impossible de se connecter au Web Service !",
                    "Problème Web Service");
                this.IsValidConnection = false;
            }
            finally
            {
                WindowManager.LoginViewModel = this;
            }
        }

        public void showErrorSignIn(String msg, String title)
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }


        # endregion Methods
    }
}
