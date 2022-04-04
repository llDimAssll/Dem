using Authorization;
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

namespace Dem
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Password;

            var result = UserAuthorization.Verification(login, password);
            if (result == 1) NavigationService.Navigate(new Uri("ListUsers.xaml", UriKind.Relative));
            else if (result == 2) MessageBox.Show($"Неверный пароль");
            else MessageBox.Show($"Пользователь с логином - {login} не найден");
        }
    }
}
