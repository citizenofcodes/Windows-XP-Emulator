using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
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

namespace FileExplorer.Applications
{
    /// <summary>
    /// Логика взаимодействия для NotePad.xaml
    /// </summary>
    public partial class NotePad : Window
    {
        private string _path;

        public NotePad()
        {
            InitializeComponent();
        }

        public NotePad(string path)
        {
            InitializeComponent();
            _path = path;
            OpenFile();
        }
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var item = ((MenuItem)e.Source).Header.ToString();

            switch (item)
            {
                case "Сохранить":
                    SaveFile();
                    break;

                case "Открыть":
                    OpenFile();
                    break;
            }
        }

        private void SaveFile()
        {
            FileStream fs = new FileStream(_path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(TextField.Text);

           
            sw.Close();
            fs.Close();

            MessageBox.Show("Saved!");
        }

        private void OpenFile()
        {
            FileStream fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                TextField.AppendText($"{line}\n");
                
            }

            fs.Close();
            sr.Close();
        }
    }
}
