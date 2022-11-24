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

namespace Wpf_Palashicheva_PR8.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRezumeAdd.xaml
    /// </summary>
    public partial class PageRezumeAdd : Page
    {
        private Rezume _currentRezume = new Rezume();
        public PageRezumeAdd()
        {
            InitializeComponent();
            DataContext = _currentRezume;
            ComboPol.ItemsSource = AgencyEntities.GetContext().Pol.ToList();

           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // проверка заполняемости полей
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentRezume.naimenov))
                errors.AppendLine("Укажите ФИО");

            if (_currentRezume.Pol == null)
                errors.AppendLine("Выберите пол");

            if (string.IsNullOrWhiteSpace(_currentRezume.job))
                errors.AppendLine("Укажите желаемую должность");

            if (_currentRezume.money <= 0)
                errors.AppendLine("Заработок не может быть меньше или равен 0");

            if (_currentRezume.birthdate == null)
                errors.AppendLine("Введите дату рождения");


            if (string.IsNullOrWhiteSpace( _currentRezume.city))
                errors.AppendLine("Введите город");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentRezume.Id == 0)
                AgencyEntities.GetContext().Rezume.Add(_currentRezume);
            try
            {
                AgencyEntities.GetContext().SaveChanges();
                MessageBox.Show("Резюме сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.GoBack();
        }
    }
}
