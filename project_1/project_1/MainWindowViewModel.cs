using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string confirmedPassword;
        private string email;
        private bool rememberMe;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string ConfirmedPassword
        {
            get { return confirmedPassword; }
            set
            {
                confirmedPassword = value;
                OnPropertyChanged("ConfirmedPassword");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public bool RememberMe
        {
            get { return rememberMe; }
            set
            {
                rememberMe = value;
                OnPropertyChanged("RememberMe");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop = "")
        {
            if (this.PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));    
        }

        public MainWindowViewModel()
        {
            login = "Введите логин";
            password = "Введите пароль";
            confirmedPassword = "Повторите пароль";
            email = "Укажите ваш Email";
            rememberMe = true;
        }
    }
}
