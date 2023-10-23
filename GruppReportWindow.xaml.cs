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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using kurs.DateBase;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для GruppReportWindow.xaml
    /// </summary>
    public partial class GruppReportWindow : Window
    {
        public GruppReportWindow()
        {
            InitializeComponent();
            GruppСbox.ItemsSource = Helper.db.Gruppas.ToList(); //предоставление данных для ComboBoх "Группа" 
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new TutorWindow().Show();
            this.Close();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            //Проверка заполнения полей группа и наименование документа 
            if (!string.IsNullOrWhiteSpace(NameDocTBox.Text) &&
                !string.IsNullOrWhiteSpace(GruppСbox.Text))
            {
                //Объект документа пдф
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                //Создаем объект записи пдф-документа в файл
                PdfWriter.GetInstance(doc, new FileStream("F:\\report\\" + NameDocTBox.Text + ".pdf", FileMode.Create));

                //Открываем документ
                doc.Open();

                //Загрузка шрифта PT-Astra
                BaseFont baseFont = BaseFont.CreateFont("F:\\ТТИТ\\курс\\kurs\\kurs\\PT-Astra-Serif_Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                //Содание переменной хранящей Сущность "группа" с определенным ID который ввел пользователь
                var grupprep = Helper.db.Gruppas.FirstOrDefault(x => x.Id == int.Parse(GruppСbox.SelectedValue.ToString())); 
                int count = 0;
                string text;
                int correctanswer = 0;
                int nocorrectanswer = 0;
                doc.Add(new iTextSharp.text.Paragraph($"Группа: {grupprep.Title} \n", font)); //добавление данных в документ 
                foreach (var j in Helper.db.Users.ToList())
                {
                    if (j.GruppaId == grupprep.Id )
                    {
                        doc.Add(new iTextSharp.text.Paragraph($"\n {j.Fname} {j.Sname} {j.Mname} \n", font)); //добавление данных в документ 
                        foreach (var i in Helper.db.PassingTests.ToList())
                        {
                                if (i.UsersId == j.Id)
                                {
                                    count++;
                                    var test = Helper.db.Tests.FirstOrDefault(x => x.Id == i.TestsId);
                                    if (i.UserResponse == test.RightAnswer)
                                    {
                                        text = "Решено вено";
                                        correctanswer++;
                                    }
                                    else
                                    {
                                        text = "Решено Не вено";
                                        nocorrectanswer++;
                                    }
                                    doc.Add(new iTextSharp.text.Paragraph($"{count} | " +
                                    $"вопрос: {test.Question} | Верный ответ: {test.RightAnswer} | Ответ: {i.UserResponse} | {text} \n ", font));
                                }
                        }
                        doc.Add(new iTextSharp.text.Paragraph($" Верных ответов: {correctanswer}        Решено не верно: {nocorrectanswer} \n", font)); //добавление данных в документ 
                        correctanswer = 0;
                        nocorrectanswer = 0;
                    }
                }
                doc.Add(new iTextSharp.text.Paragraph($"\n{CommentTBox.Text}\n", font)); //добавление данных в документ 
                doc.Close(); //закрытие документа 
                MessageBox.Show("успешно");
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
