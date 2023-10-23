using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для CreateQuestionWindow.xaml
    /// </summary>
    public partial class CreateQuestionWindow : Window
    {
        public CreateQuestionWindow()
        {
            InitializeComponent();
            ScopeApplicationTbox.ItemsSource = Helper.db.ScopeApplications.ToList(); //предоставление данных для ComboBoх "Область" 
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //проверка заполнения всех полей 
            if (!string.IsNullOrWhiteSpace(QuestionTbox.Text) &&
                !string.IsNullOrWhiteSpace(RightAnswerTbox.Text) &&
                !string.IsNullOrWhiteSpace(ScopeApplicationTbox.Text) )
            {
                // присваевание данных веденных пользователем атрибутам сущности базы данных
                DateBase.Test test = new DateBase.Test()
                {
                    Question = QuestionTbox.Text,
                    RightAnswer = RightAnswerTbox.Text,
                    UserCreateId = Helper.usersession.Id,
                    ScopeApplicationId = int.Parse(ScopeApplicationTbox.SelectedValue.ToString())
                };
                    Helper.db.Add(test);// добавление данных веденных порльзователем в базу данных
                    Helper.db.SaveChanges();// сохранение данных 
                    MessageBox.Show("Задание добавлено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Обработчик нажжатия кнопуи "назад"
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
