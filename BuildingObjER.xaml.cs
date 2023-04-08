using kapustinRPMBD;
using System;
using System.Windows;
namespace KapustinRPMBDPR2
{    
    public partial class BuildingObjER : Window
    {
        public BuildingObjER()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        BuildingObject _objectBuildingObjDB = new BuildingObject();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _objectBuildingObjDB = _dataBase.BuildingObjects.Find(DataBaseSupClass.BuildingObjectName, DataBaseSupClass.BuildingObjectRegionId, DataBaseSupClass.BuildingObjectSectorId, DataBaseSupClass.BuildingObjectOrganizationId);
            BuildingObjectNameTB.Text = _objectBuildingObjDB.BuildingObjectName;
            RegionIdTB.Text = _objectBuildingObjDB.RegionId.ToString();
            SectorIdTB.Text = _objectBuildingObjDB.SectorId.ToString();
            OrganizationIdTB.Text = _objectBuildingObjDB.OrganizationId.ToString();
            FinanceOfFirstQuartTB.Text = _objectBuildingObjDB.FinanceOfFirstQuart.ToString();
            FinanceOfSecondQuartTB.Text = _objectBuildingObjDB.FinanceOfSecondQuart.ToString();
            FinanceOfThirdQuartTB.Text = _objectBuildingObjDB.FinanceOfThirdQuart.ToString();
            FinanceOfFourthQuartTB.Text = _objectBuildingObjDB.FinanceOfFourthQuart.ToString();
            EnterYearTB.Text = _objectBuildingObjDB.EnterYear.Year.ToString();
        }
        private void EditRecordBTN_Click(object sender, RoutedEventArgs e)
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
                _objectBuildingObjDB.EnterYear = Convert.ToDateTime(string.Concat(EnterYearTB.Text, ".01.01"));                
            }
            catch (Exception)
            {
                MessageBox.Show("Возможно, вводимые вами данные не содержатся в других соответствующих таблицах.\nПерепроверьте данные и попробуйте снова.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
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