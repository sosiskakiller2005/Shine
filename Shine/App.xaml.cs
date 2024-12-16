using Shine.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shine
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ShineDbEntities _context;
        public static ShineDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new ShineDbEntities();
            }
            return _context;
        }
    }
}
