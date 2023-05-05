using System.Linq;
using System.Windows;

namespace KapustinRPMBDPR2
{
    public partial class Querries : Window
    {
        public Querries()
        {
            InitializeComponent();
        }
        Entities _dataBase = Entities.GetContext();
        private void FirstQuerryBTN_Click(object sender, RoutedEventArgs e)
        {
            /*var firstSqlResults = from reg in _dataBase.Regions
                                  join bo in _dataBase.BuildingObjects
                                  on reg.RegionId equals bo.RegionId
                                  group reg by reg.RegionName into result
                                  select new
                                  { 
                                     
                                  };

            Dg.ItemsSource = firstSqlResults.ToList();*/
        }
        private void SecondQuerryBTN_Click(object sender, RoutedEventArgs e)
        {
            var secondSqlResults = from reg in _dataBase.Regions
                                   join bo in _dataBase.BuildingObjects
                                   on reg.RegionId equals bo.RegionId
                                   join sec in _dataBase.Sectors
                                   on bo.SectorId equals sec.SectorId
                                   select new
                                   {
                                       reg.RegionName,
                                       sec.SectorName,
                                       bo.BuildingObjectName,
                                       bo.EnterYear
                                   };
            Dg.ItemsSource = secondSqlResults.ToList();
        }
    }
}