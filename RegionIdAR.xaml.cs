using System;
using System.Windows;

namespace KapustinRPMBDPR2
{    
    public partial class RegionIdAR : Window
    {
        public RegionIdAR()
        {
            InitializeComponent();
        }

        Entities _dataBase = Entities.GetContext();

        Region _objectRegionIdDB = new Region();

        private void AddRecordBTN_Click(object sender, RoutedEventArgs e)
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

            _objectRegionIdDB.RegionId = Math.Abs(regionId);
            _objectRegionIdDB.RegionName = RegionNameTB.Text;

            //Добавляем данные в базу данных
            _dataBase.Regions.Add(_objectRegionIdDB);
            MessageBox.Show("Информация успешно сохранена.", "Добавление прошло успешно!");
            //Сохраняем изменения
            _dataBase.SaveChanges();
            Close();
        }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
