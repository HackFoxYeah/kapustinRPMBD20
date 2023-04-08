using kapustinRPMBD;
using System;
using System.Windows;
namespace KapustinRPMBDPR2
{
    public partial class SectorER : Window
    {
        public SectorER()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        Sector _objectSectorId;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _objectSectorId = _dataBase.Sectors.Find(DataBaseSupClass.SectorId);
            SectorIdTB.Text = _objectSectorId.SectorId.ToString();
            SectorNameTB.Text = _objectSectorId.SectorName;
        }
        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "Проверьте корректность ввода следующих данных:\n";
            if (!int.TryParse(SectorIdTB.Text, out int sectorId))
                errorMessage += "+ Номер области\n";
            if (string.IsNullOrEmpty(SectorNameTB.Text))
                errorMessage += "+ Имя области\n";
            if (errorMessage.Split(' ').Length > 5)
            {
                MessageBox.Show(errorMessage, "Обнаружены ошибки!");
                Close();
                return;
            }
            _objectSectorId.SectorId = Math.Abs(sectorId);
            _objectSectorId.SectorName = SectorNameTB.Text;
            MessageBox.Show("Информация успешно сохранена.", "Добавление прошло успешно!");
            _dataBase.SaveChanges();
            Close();
        }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}