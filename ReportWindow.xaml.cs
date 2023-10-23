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
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }
        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserReportWindow().Show();
            this.Close();
        }

        private void GruppBtn_Click(object sender, RoutedEventArgs e)
        {
            new GruppReportWindow().Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new TutorWindow().Show();
            this.Close();
        }
    }
}
