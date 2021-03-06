﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using project_1.Data.DataModels;

namespace project_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, 
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = (MainWindowViewModel)this.DataContext;
                
                
                var user = new User();
                user.Login = model.Login;
                user.Password = model.Password;
                user.Email = model.Email;

                if (!user.Validate())
                {
                    MessageBox.Show("Вы незаполнили форму", "Ошибки валидации", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation, MessageBoxResult.None);
                    return;
                }

                var isExistResult = false;
                using (var db = new DataBaseModel())
                {
                    isExistResult = db.Users.Any(u=> u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase) &&
                    u.Login.Equals(user.Login) && u.Password.Equals(user.Password));
                }

                if (!isExistResult)
                {
                    MessageBox.Show("Такого пользователя не существует", "Ошибки валидации", MessageBoxButton.OK,
                        MessageBoxImage.Information, MessageBoxResult.None);
                }
                else
                {
                    MessageBox.Show("Вход выполнен", "Вход выполнен", MessageBoxButton.OK,
                        MessageBoxImage.Information, MessageBoxResult.None);

                    MessageBox.Show($"Привет, {model.Login}!", "Приветствие",MessageBoxButton.OK, 
                        MessageBoxImage.None, MessageBoxResult.None);
                }

                
            }
            catch(Exception exp)
            {
                var message = "Приносим извинения, произошла ошибка\n" + exp.Message;
                MessageBox.Show(message, "Сведения об ошибке", 
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                
                //todo: залогировать
            }
            
            
        }
    }
}
