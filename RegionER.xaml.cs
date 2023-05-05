using kapustinRPMBD;
using System;
using System.Windows;
namespace KapustinRPMBDPR2
{
    public partial class RegionER : Window
    {
        public RegionER()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        Region _objectRegionId;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _objectRegionId = _dataBase.Regions.Find(DataBaseSupClass.RegionId);
            RegionIdTB.Text = _objectRegionId.RegionId.ToString();
            RegionNameTB.Text = _objectRegionId.RegionName;
        }
        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "Проверьте корректность ввода следующих данных:\n";
            if (!int.TryParse(RegionIdTB.Text, out int regionId))
                errorMessage += "+ Номер региона\n";
            if (string.IsNullOrEmpty(RegionNameTB.Text))
                errorMessage += "+ Имя региона\n";
            if (errorMessage.Split(' ').Length > 5)
            {
                MessageBox.Show(errorMessage, "Обнаружены ошибки!");
                Close();
                return;
            }
            try
            {
                _dataBase.Regions.Remove(_objectRegionId);
                _dataBase.SaveChanges();
                _objectRegionId.RegionId = Math.Abs(regionId);
                _objectRegionId.RegionName = RegionNameTB.Text;
                _dataBase.Regions.Add(_objectRegionId);
                MessageBox.Show("Информация успешно сохранена.", "Добавление прошло успешно!");
                _dataBase.SaveChanges();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Попытка удалить связанные записи! Сначала уберите зависимости!", "Конфликт связей");
                _dataBase.Regions.Add(_objectRegionId);
                Close();
            }
        }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}