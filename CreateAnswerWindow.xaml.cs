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
    /// Логика взаимодействия для CreateAnswerWindow.xaml
    /// </summary>
    public partial class CreateAnswerWindow : Window
    {
        public CreateAnswerWindow()
        {
            InitializeComponent();
            UserRespTbox.ItemsSource = Helper.db.Users.ToList(); // предоставление данных для ComboBoх ФИО
            TestTbox.ItemsSource = Helper.db.Tests.ToList(); // предоставление данных для ComboBoх Вопрос

        }
        /// <summary>
        /// обраточик нажатия кнопки "сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // проверка заполнения всех полей 
            if (!string.IsNullOrWhiteSpace(UserRespTbox.Text) &&
                !string.IsNullOrWhiteSpace(TestTbox.Text) &&
                !string.IsNullOrWhiteSpace(ResponseTbox.Text) && !string.IsNullOrWhiteSpace(DateTestTbox.ToString()))
            {
                // присваевание данных веденных пользователем атрибутам сущности базы данных
                DateBase.PassingTest passingTest = new DateBase.PassingTest()
                {
                    UsersId = int.Parse(UserRespTbox.SelectedValue.ToString()),
                    TestsId = int.Parse(TestTbox.SelectedValue.ToString()),
                    UserResponse = ResponseTbox.Text,
                    DatePasses = DateTime.Parse(DateTestTbox.ToString())
                };
                Helper.db.Add(passingTest); // добавление данных веденных порльзователем в базу данных
                Helper.db.SaveChanges(); // сохранение данных 
                MessageBox.Show("Задание добавлено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }




        }
        /// <summary>
        /// обработчик начатия кнопки "назад" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new TutorWindow().Show();
            this.Close();
        }
    }
}
