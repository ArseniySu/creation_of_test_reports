using kurs.DateBase;
using System;
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
using System.Windows.Shapes;

namespace kurs
{
    /// <summary>
    /// Класс описивыющий фенкционал окна авторизации
    /// </summary>
    public partial class AutoWindow : Window
    {
        public AutoWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Вход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на заполнения полей логин и пароль 
            if (!string.IsNullOrWhiteSpace(LoginTBox.Text) && !string.IsNullOrWhiteSpace(PasswordTBox.Password))
            {
                User user = Auth(LoginTBox.Text, PasswordTBox.Password);
                // проверка наличия пользователя с ведеными логиноми паролем 
                if (user != null)
                {
                    Helper.usersession = user;
                    var tutor = Helper.db.Gruppas.FirstOrDefault(x => x.Title == "куратор"); // содание переменной хронящей определенную роль пользователя 
                    // проверка наличия роли и переход в соответствующее окно с функционалом для данной роли 
                    if (user.GruppaId == tutor.Id)
                    {
                        new TutorWindow().Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
        /// <summary>
        /// Фенкция проверки наличия совпадений логина и пароля в базе данных 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Auth(string login, string password)
        {
            return Helper.db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

    }
}
