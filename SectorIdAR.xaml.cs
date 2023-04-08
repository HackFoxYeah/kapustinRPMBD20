using System;
using System.Windows;

namespace KapustinRPMBDPR2
{
    /// <summary>
    /// Логика взаимодействия для SectorIdAR.xaml
    /// </summary>
    public partial class SectorIdAR : Window
    {
        public SectorIdAR()
        {
            InitializeComponent();
        }

        Entities _dataBase = Entities.GetContext();

        Sector _objectSectorIdDB = new Sector();

        private void AddRecordBTN_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "Проверьте корректность ввода следующих данных:\n";

            if (!int.TryParse(SectorIdTB.Text, out int sectorId))
                errorMessage += "+ Номер области\n";

            if (string.IsNullOrEmpty(SectorNameTB.Text))
                errorMessage += "+ Имя область\n";

            if (errorMessage.Split(' ').Length != 5)
            {
                MessageBox.Show(errorMessage, "Обнаружены ошибки!");
                Close();
                return;
            }

            _objectSectorIdDB.SectorId = Math.Abs(sectorId);
            _objectSectorIdDB.SectorName = SectorNameTB.Text;

            //Добавляем данные в базу данных
            _dataBase.Sectors.Add(_objectSectorIdDB);
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
