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
using Wpf_Palashicheva_PR8.ApplicationData;

namespace Wpf_Palashicheva_PR8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelOdb = new AgencyEntities(); // подключение к БД
            AppFrame.frameMain = FrmMain; //загрузка фрейма с началом работы программы

            FrmMain.Navigate(new PageLogin.PageLogin()); //подключение во фрейм стартовой страницы авторизации
        }
    }
}
