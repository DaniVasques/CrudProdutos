using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProdutos.Settings
{
    public class AppSetting
    {
        public static string GetConnectionString ()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutos;Integrated Security=True;"; 
        } 
    }
}
