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
            _objectBuildingOrgDB.OrganizationId = Math.Abs(orgId);
            _objectBuildingOrgDB.OrganizationName = OrgNameTB.Text;
            _objectBuildingOrgDB.Address = AddressTB.Text;
            _objectBuildingOrgDB.PhoneNumber = PhoneNumberTB.Text;
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