using kurs.DateBase;
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
using System.Windows.Shapes;

namespace kurs
{

    public partial class UserAdminWindow : Window
    {
        public UserAdminWindow()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            UserDGrid.ItemsSource = Helper.db.Users.Include(z => z.Gruppa).ToList(); // Выборка данных для заполнения таблицы Grid 
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new TutorWindow().Show();
            this.Close();
        }

        private void NewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            new NewUserWindow().Show();
            this.Close();
        }
    }
}
