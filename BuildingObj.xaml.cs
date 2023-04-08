using System;
using System.Windows;
namespace KapustinRPMBDPR2
{
    public partial class BuildingObj : Window
    {
        public BuildingObj()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        BuildingObject _objectBuildingObjDB = new BuildingObject();
        private void AddRecordBTN_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "Проверьте корректность ввода следующих данных:\n";
            try
            {
                if (string.IsNullOrEmpty(BuildingObjectNameTB.Text))
                    errorMessage += "+ Имя объекта\n";
                if (!int.TryParse(RegionIdTB.Text, out int regionId))
                    errorMessage += "+ Номер региона\n";
                if (!int.TryParse(SectorIdTB.Text, out int sectorId))
                    errorMessage += "+ Номер области\n";
                if (!int.TryParse(OrganizationIdTB.Text, out int orgId))
                    errorMessage += "+ Номер организации\n";
                if (!int.TryParse(FinanceOfFirstQuartTB.Text, out int finFirstId))
                    errorMessage += "+ Финансы за первый квартал\n";
                if (!int.TryParse(FinanceOfSecondQuartTB.Text, out int finSecondId))
                    errorMessage += "+ Финансы за второй квартал\n";
                if (!int.TryParse(FinanceOfThirdQuartTB.Text, out int finThirdId))
                    errorMessage += "+ Финансы за третий квартал\n";
                if (!int.TryParse(FinanceOfFourthQuartTB.Text, out int finFouthId))
                    errorMessage += "+ Финансы за четвёртый квартал\n";
                if (EnterYearTB.Text.Length != 4)
                    errorMessage += "+ Год входа\n";
                if (errorMessage.Split(' ').Length > 5)
                {
                    MessageBox.Show(errorMessage, "Обнаружены ошибки!");
                    Close();
                    return;
                }
                _objectBuildingObjDB.BuildingObjectName = BuildingObjectNameTB.Text;
                _objectBuildingObjDB.RegionId = regionId;
                _objectBuildingObjDB.SectorId = sectorId;
                _objectBuildingObjDB.OrganizationId = orgId;
                _objectBuildingObjDB.FinanceOfFirstQuart = finFirstId;
                _objectBuildingObjDB.FinanceOfSecondQuart = finSecondId;
                _objectBuildingObjDB.FinanceOfThirdQuart = finThirdId;
                _objectBuildingObjDB.FinanceOfFourthQuart = finFouthId;
                _objectBuildingObjDB.EnterYear = Convert.ToDateTime(EnterYearTB.Text + ".01.01");
                //Добавляем данные в базу данных
                _dataBase.BuildingObjects.Add(_objectBuildingObjDB);
                MessageBox.Show("Информация успешно сохранена.", "Добавление прошло успешно!");
                //Сохраняем изменения
                _dataBase.SaveChanges();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Возможно, вводимые вами данные не содержатся в других соответствующих таблицах.\nПерепроверьте данные и попробуйте снова.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}