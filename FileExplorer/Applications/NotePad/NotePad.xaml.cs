using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileExplorer.Applications.NotePad
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
