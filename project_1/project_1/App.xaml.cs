using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace project_1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Нулевое обращение к бд для ускорения доступа к данным при последующих обращениях
            Task.Run(() =>
            {
                try
                {
                    using (var db = new Data.DataModels.DataBaseModel())
                    {
                        db.Users.Count();
                    }
                }
                catch { }
            });
        }
    }
}
