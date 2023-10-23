using kurs.DateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            InitializeComponent();
            gruppTbox.ItemsSource = Helper.db.Gruppas.ToList();//предоставление данных для ComboBoх Группа
            genderTbox.ItemsSource = Helper.db.Genders.ToList();//предоставление данных для ComboBoх Пол
        }
        /// <summary>
        /// обработчик нажатия кнопки "сохранить" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Проверка заполнения полей 
            if (!string.IsNullOrWhiteSpace(FnameTbox.Text) && !string.IsNullOrWhiteSpace(SNameTbox.Text) &&
                !string.IsNullOrWhiteSpace(gruppTbox.Text) && !string.IsNullOrWhiteSpace(LogTbox.Text) &&
                !string.IsNullOrWhiteSpace(PassTbox.Text) && !string.IsNullOrWhiteSpace(DateBirthTbox.ToString()) &&
                !string.IsNullOrWhiteSpace(genderTbox.Text))
            {
                // Проверка введенных символов 
                if (Regex.IsMatch(LogTbox.Text, @"[a-z]$") &&
                                Regex.IsMatch(PassTbox.Text, @"[a-z]$") &&
                                Regex.IsMatch(FnameTbox.Text, @"[а-я]$") &&
                                Regex.IsMatch(SNameTbox.Text, @"[а-я]$") &&
                                Regex.IsMatch(MnameTbox.Text, @"[а-я]$"))
                {


                    DateBase.User user = Helper.db.Users.FirstOrDefault(q => q.Login == LogTbox.Text);
                    // присваевание данных веденных пользователем атрибутам сущности базы данных
                    if (user == null)
                    {
                        DateBase.User users = new DateBase.User()
                        {

                            Fname = FnameTbox.Text,
                            Sname = SNameTbox.Text,
                            Mname = MnameTbox.Text,
                            GruppaId = int.Parse(gruppTbox.SelectedValue.ToString()),
                            DateBirth = DateTime.Parse(DateBirthTbox.ToString()),
                            Login = LogTbox.Text,
                            Password = PassTbox.Text,
                            GenderId = int.Parse(genderTbox.SelectedValue.ToString())
                        };

                        Helper.db.Add(users); //добавление данных в базу данных
                        Helper.db.SaveChanges(); //Сохранение данных
                        MessageBox.Show("Регистрация успешна", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        new UserAdminWindow().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Логин уже существует", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Введены недопустимые символы", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// обработчик нажатия кнопки "назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserAdminWindow().Show();
            this.Close();
        }


    }
}
