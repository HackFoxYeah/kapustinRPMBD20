using kapustinRPMBD;
using System.Data.Entity;
using System.Windows;

namespace KapustinRPMBDPR2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Entities _dataBase = new Entities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицы из базы данных.
            _dataBase.Regions.Load();
            _dataBase.Sectors.Load();
            _dataBase.BuildingObjects.Load();
            _dataBase.BuildingOrganizations.Load();
            //Загружаем таблиц в DataGrid с отслеживанием контекста.
            RegionIdDG.ItemsSource = _dataBase.Regions.Local.ToBindingList();
            SectorIdDG.ItemsSource = _dataBase.Sectors.Local.ToBindingList();
            BuildingOrganizationDG.ItemsSource = _dataBase.BuildingOrganizations.Local.ToBindingList();
            BuildingObjectDG.ItemsSource = _dataBase.BuildingObjects.Local.ToBindingList();
        }
        private void RegionIdCreateRec_Click(object sender, RoutedEventArgs e)
        {
            var regAddRec = new RegionIdAR();
            regAddRec.ShowDialog();
            _dataBase.Regions.Load();
            RegionIdDG.Focus();
        }
        private void SectorIdCreateRec_Click(object sender, RoutedEventArgs e)
        {
            var sectAddRec = new SectorIdAR();
            sectAddRec.ShowDialog();
            _dataBase.Sectors.Load();
            SectorIdDG.Focus();
        }
        private void BuildingOrganizationCreateRec_Click(object sender, RoutedEventArgs e)
        {
            var buildingOrgAddRec = new BuildingOrgAR();
            buildingOrgAddRec.ShowDialog();
            _dataBase.BuildingOrganizations.Load();
            BuildingOrganizationDG.Focus();
        }
        private void BuildingObjectCreateRec_Click(object sender, RoutedEventArgs e)
        {
            var regAddRec = new BuildingObj();
            regAddRec.ShowDialog();
            _dataBase.BuildingObjects.Load();
            BuildingObjectDG.Focus();
        }
        private void RegionIdEditRec_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = RegionIdDG.SelectedIndex;
            if (indexRow != -1)
            {
                Region row = (Region)RegionIdDG.Items[indexRow];
                DataBaseSupClass.RegionId = row.RegionId;
                DataBaseSupClass.RegionName = row.RegionName;
                RegionER erForm = new RegionER();
                erForm.ShowDialog();
                RegionIdDG.Items.Refresh();
                RegionIdDG.Focus();
            }
        }
        private void SectorIdEditRec_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = SectorIdDG.SelectedIndex;
            if (indexRow != -1)
            {
                Sector row = (Sector)SectorIdDG.Items[indexRow];
                DataBaseSupClass.SectorId = row.SectorId;
                DataBaseSupClass.SectorName = row.SectorName;
                SectorER erForm = new SectorER();
                erForm.ShowDialog();
                SectorIdDG.Items.Refresh();
                SectorIdDG.Focus();
            }
        }
        private void BuildingOrganizationEditRec_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = BuildingOrganizationDG.SelectedIndex;
            if (indexRow != -1)
            {
                BuildingOrganization row = (BuildingOrganization)BuildingOrganizationDG.Items[indexRow];
                DataBaseSupClass.OrganizationId = row.OrganizationId;
                DataBaseSupClass.OrganizationName = row.OrganizationName;
                DataBaseSupClass.Address = row.Address;
                DataBaseSupClass.PhoneNumber = row.PhoneNumber;
                BuildingOrgER buildingOrgER = new BuildingOrgER();
                buildingOrgER.ShowDialog();
                BuildingOrganizationDG.Items.Refresh();
                BuildingOrganizationDG.Focus();
            }
        }
        private void BuildingObjectEditRec_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = BuildingObjectDG.SelectedIndex;
            if (indexRow != -1)
            {
                BuildingObject row = (BuildingObject)BuildingObjectDG.Items[indexRow];
                DataBaseSupClass.BuildingObjectName = row.BuildingObjectName;
                DataBaseSupClass.BuildingObjectRegionId = row.RegionId;
                DataBaseSupClass.BuildingObjectSectorId = row.SectorId;
                DataBaseSupClass.BuildingObjectOrganizationId = row.OrganizationId;
                DataBaseSupClass.FinanceOfFirtsQuart = row.FinanceOfFirstQuart;
                DataBaseSupClass.FinanceOfSecondQuart = row.FinanceOfSecondQuart;
                DataBaseSupClass.FinanceOfThirdQuart = row.FinanceOfThirdQuart;
                DataBaseSupClass.FinanceOfFourthQuart = row.FinanceOfFourthQuart;
                DataBaseSupClass.EnterYear = row.EnterYear;
                BuildingObjER erForm = new BuildingObjER();
                erForm.ShowDialog();
                BuildingObjectDG.Items.Refresh();
                BuildingObjectDG.Focus();
            }
        }
        private void RegionIdRemoveRec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Region row = (Region)RegionIdDG.SelectedItems[0];
                    _dataBase.Regions.Remove(row);
                    _dataBase.SaveChanges();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void SectorIdRemoveRec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Sector row = (Sector)SectorIdDG.SelectedItems[0];
                    _dataBase.Sectors.Remove(row);
                    _dataBase.SaveChanges();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void BuildingOrganizationRemoveRec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    BuildingOrganization row = (BuildingOrganization)BuildingOrganizationDG.SelectedItems[0];
                    _dataBase.BuildingOrganizations.Remove(row);
                    _dataBase.SaveChanges();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void BuildingObjectRemoveRec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    BuildingObject row = (BuildingObject)BuildingObjectDG.SelectedItems[0];
                    _dataBase.BuildingObjects.Remove(row);
                    _dataBase.SaveChanges();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Querries_Click(object sender, RoutedEventArgs e)
        {
            Querries wind = new Querries();
            wind.ShowDialog();
        }
    }
}