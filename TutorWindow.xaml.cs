using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
using System.Xml.Linq;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для TutorWindow.xaml
    /// </summary>
    public partial class TutorWindow : Window
    {
        public TutorWindow()
        {
            InitializeComponent();
        }

        private void worksBtn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new AutoWindow().Show();   
            this.Close();
        }

        private void CreateReportBtn_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
            this.Close();
        }

        private void CreateTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreateQuestionWindow().Show();
            this.Close();
        }

        private void CreateAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreateAnswerWindow().Show();
            this.Close();
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserAdminWindow().Show();
            this.Close();
        }
    }
}
