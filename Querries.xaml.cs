using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KapustinRPMBDPR2
{    
    public partial class Querries : Window
    {
        public Querries()
        {
            InitializeComponent();
        }
        Entities _dataBase = new Entities();
        private void FirstQuerryBTN_Click(object sender, RoutedEventArgs e)
        {
            var firstSqlResults = from reg in _dataBase.Regions
                                  join bo in _dataBase.BuildingObjects
                                  on reg.RegionId equals bo.RegionId
                                  select new
                                  {
                                      reg.RegionName,
                                      count = bo.BuildingObjectName.Count()
                                  };
            FirstTB.Text = "from reg in _dataBase.Regions\r\n                                  join bo in _dataBase.BuildingObjects\r\n                                  on reg.RegionId equals bo.RegionId\r\n                                  select new\r\n                                  {\r\n                                      reg.RegionName,\r\n                                      count = bo.BuildingObjectName.Count()\r\n                                  }; ";
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
            SecondTB.Text = "from reg in _dataBase.Regions\r\n                                   join bo in _dataBase.BuildingObjects\r\n                                   on reg.RegionId equals bo.RegionId\r\n                                   join sec in _dataBase.Sectors\r\n                                   on bo.SectorId equals sec.SectorId\r\n                                   select new\r\n                                   {\r\n                                       reg.RegionName,\r\n                                       sec.SectorName,\r\n                                       bo.BuildingObjectName,\r\n                                       bo.EnterYear\r\n                                   };";
        }
    }
}