using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class Login : Window
    {
        TimeSpan sec;
        DispatcherTimer _timer;
        int n = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_btn(object sender, RoutedEventArgs e)
        {
            int nn = 0;
            int nnn = 0;
            bool b = false;
            string[] parts = { };
            string[] lines = File.ReadAllLines("file.txt");
            foreach (string line in lines)
            {
                parts = line.Split('\t');

                nn = parts.Length - 6;
                nnn = parts.Length - 5;
                if (Login_box.Text == parts[nn] && Password_box.Text == parts[nnn])
                {
                    b = true;
                }
            }
            if ((Login_box.Text != "" && Password_box.Text != "") && (b))
            {
                MessageBox.Show("Вы успешно авторизовались");
                // CreateWindow cw = new CreateWindow();
                // cw.Show();
                // this.Close();
            }
            else
            {
                n++;
                if (n == 3)
                {
                    MessageBox.Show("Вы 3 раза ввели не правильные данные, поэтому доступ к приложению ограничен на 5 секунд");
                    sec = TimeSpan.FromSeconds(5);
                    btn.IsEnabled = false;

                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                        if (sec == TimeSpan.Zero)
                        {
                            _timer.Stop();
                            MessageBox.Show("Попробуйте снова");
                            btn.IsEnabled = true;
                        }
                        sec = sec.Add(TimeSpan.FromSeconds(-1));
                    }, Application.Current.Dispatcher);
                    _timer.Start();
                    n = 0;
                }
                else
                {
                    MessageBox.Show("Неверные данные");
                }
            }
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Close_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
