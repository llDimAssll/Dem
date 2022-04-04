using Dem.Models;
using Services;
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
    /// Логика взаимодействия для ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Page
    {
        public ListUsers()
        {
            InitializeComponent();
        }

        private readonly UserService _userService = new UserService();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectUser = (Clients)ListUser1.SelectedItem;
            await _userService.Delete(selectUser);
            ListUser1.ItemsSource = await _userService.GetAll();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            var clients = await _userService.SearchByName(SearchText.Text);
            ListUser1.ItemsSource = clients.ToList();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListUser1.ItemsSource = await _userService.GetAll();
        }
    }
}
