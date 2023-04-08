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
using System.Windows.Shapes;

namespace KapustinRPMBDPR2
{    
    public partial class BuildingOrgAR : Window
    {
        public BuildingOrgAR()
        {
            InitializeComponent();
        }

        Entities _dataBase = Entities.GetContext();

        BuildingOrganization _objectBuildingOrgDB = new BuildingOrganization();

        private void AddRecordBTN_Click(object sender, RoutedEventArgs e)
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

            //Добавляем данные в базу данных
            _dataBase.BuildingOrganizations.Add(_objectBuildingOrgDB);
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
