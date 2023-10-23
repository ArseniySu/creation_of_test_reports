using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }
        /// <summary>
        /// Выборка данных для заполнения таблицы Grid
        /// </summary>
        private void InitData()
        {
            UserDGrid.ItemsSource = Helper.db.PassingTests.Include(z => z.Users).Include(z => z.Tests).ToList();
        }
        /// <summary>
        /// обработчик нажания кноки "назад"
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
