using kapustinRPMBD;
using System;
using System.Windows;

namespace KapustinRPMBDPR2
{
    public partial class BuildingOrgER : Window
    {
        public BuildingOrgER()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        BuildingOrganization _objectBuildingOrgDB;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _objectBuildingOrgDB = _dataBase.BuildingOrganizations.Find(DataBaseSupClass.OrganizationId);
            OrgIdTB.Text = _objectBuildingOrgDB.OrganizationId.ToString();
            OrgNameTB.Text = _objectBuildingOrgDB.OrganizationName;
            AddressTB.Text = _objectBuildingOrgDB.Address;
            PhoneNumberTB.Text = _objectBuildingOrgDB.PhoneNumber;
        }
        private void EditRecordBTN_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "Проверьте корректность ввода следующих данных:\n";
            if (!int.TryParse(OrgIdTB.Text, out int orgId))
                errorMessage += "+ Номер организации\n";
            if (string.IsNullOrEmpty(OrgNameTB.Text))
                errorMessage += "+ Название организации\n";
            if (string.IsNullOrEmpty(AddressTB.Text))
                errorMessage += "+ Адрес\n";
            if (string.IsNullOrEmpty(PhoneNumberTB.Text))
                errorMessage += "+ Номер телефона\n";
            if (errorMessage.Split(' ').Length > 5)
            {
                MessageBox.Show(errorMessage, "Обнаружены ошибки!");
                Close();
                return;
            }
            try
            {
                _dataBase.BuildingOrganizations.Remove(_objectBuildingOrgDB);
                _dataBase.SaveChanges();
                _objectBuildingOrgDB.OrganizationId = Math.Abs(orgId);
                _objectBuildingOrgDB.OrganizationName = OrgNameTB.Text;
                _objectBuildingOrgDB.Address = AddressTB.Text;
                _objectBuildingOrgDB.PhoneNumber = PhoneNumberTB.Text;
                _dataBase.BuildingOrganizations.Add(_objectBuildingOrgDB);
                MessageBox.Show("Информация успешно сохранена.", "Добавление прошло успешно!");
                _dataBase.SaveChanges();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Попытка удалить связанные записи! Сначала уберите зависимости!", "Конфликт связей");
                _dataBase.BuildingOrganizations.Add(_objectBuildingOrgDB);
                Close();
            }            
        }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}