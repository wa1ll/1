using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    public partial class Registration : Window
    {
        bool check = true;

        public Registration()
        {
            InitializeComponent();
        }


        private void Login_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^([a-zA-Z0-9])+$");
            if (Login_box.Text.Length != 0)
            {
                if (!r.IsMatch(Login_box.Text))
                {
                    check = false;
                    Login_box.BorderBrush = Brushes.Red;
                    Login_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Login_box.BorderBrush = Brushes.Green;
                    Login_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Password_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^([a-zA-Z0-9])+$");
            if (Password_box.Text.Length != 0)
            {
                if (!r.IsMatch(Password_box.Text))
                {
                    check = false;
                    Password_box.BorderBrush = Brushes.Red;
                    Password_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Password_box.BorderBrush = Brushes.Green;
                    Password_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Famil_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^([[А-Я])([а-я])+$");
            if (Famil_box.Text.Length != 0)
            {
                if (!r.IsMatch(Famil_box.Text))
                {
                    check = false;
                    Famil_box.BorderBrush = Brushes.Red;
                    Famil_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Famil_box.BorderBrush = Brushes.Green;
                    Famil_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Name_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^([[А-Я])([а-я])+$");
            if (Name_box.Text.Length != 0)
            {
                if (!r.IsMatch(Famil_box.Text))
                {
                    check = false;
                    Name_box.BorderBrush = Brushes.Red;
                    Name_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Name_box.BorderBrush = Brushes.Green;
                    Name_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Email_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^(([a-z]|[A-Z]|[0-9]))(\w+)@([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$");
            if (Email_box.Text.Length != 0)
            {
                if (!r.IsMatch(Email_box.Text))
                {
                    check = false;
                    Email_box.BorderBrush = Brushes.Red;
                    Email_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Email_box.BorderBrush = Brushes.Green;
                    Email_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Number_tb(object sender, TextChangedEventArgs e)
        {
            Regex r = new Regex(@"^((\+7|8)+([0-9]){10})$");
            if (Number_box.Text.Length != 0)
            {
                if (!r.IsMatch(Number_box.Text))
                {
                    check = false;
                    Number_box.BorderBrush = Brushes.Red;
                    Number_box.Foreground = Brushes.Red;
                }
                else
                {
                    check = true;
                    Number_box.BorderBrush = Brushes.Green;
                    Number_box.Foreground = Brushes.Green;
                }
            }
        }

        private void Register_btn(object sender, RoutedEventArgs e)
        {
            if (Login_box.Text == "" || Password_box.Text == "" || Famil_box.Text == "" || Name_box.Text == "" || Email_box.Text == "" || Number_box.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены");
            }

            if (check == false)
            {
                MessageBox.Show("Данные не корректны");
            }
            else
            {
                string line = Login_box.Text + "\t" +
                                Password_box.Text + "\t" +
                                Famil_box.Text + "\t" +
                                Name_box.Text + "\t";

                //if (Patronymic_Box.Text.Length != 0) line += Patronymic_Box.Text + "\t";
                //line += SP_Box.Text + "\t" +
                //      NP_Box.Text + "\t";

                if (Number_box.Text.Length != 0) line += Email_box.Text + "\t"; 
                line += "\n";

                File.AppendAllText("file.txt", line);
                MessageBox.Show("Регистрация прошла успешно");
                Login_box.Text = Password_box.Text = Famil_box.Text = Name_box.Text = Email_box.Text = Number_box.Text = "";
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
