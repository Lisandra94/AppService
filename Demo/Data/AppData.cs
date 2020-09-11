using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.DBContext;

namespace App.Data
{
    public class AppData
    {
        public static async Task Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();


        }
    }
}
