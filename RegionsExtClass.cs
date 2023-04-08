using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapustinRPMBDPR2
{
    public partial class Entities
    {
        private static Entities _context;

        public static Entities GetContext()
        {
            if (_context == null)
                _context = new Entities();
            return _context;
        }
    }
}
