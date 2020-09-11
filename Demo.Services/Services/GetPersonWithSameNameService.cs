using System;
using System.Collections.Generic;
using System.Text;
using App.Services.Interfaces;
using App.Services.DBContext;
using App.Services.Models;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace App.Services.Services
{
   public class GetPersonWithSameNameService : IGetPersonWithSameNameService
    {

        public static readonly int Zero = 0;
        private readonly AppDBContext _context;

        public GetPersonWithSameNameService (AppDBContext context)
        {
            _context = context;

        }

        public async Task<List<int>> GetPersonWithSameName(string name, bool firstname)
        {
            var firstname_parameter = new SqlParameter("@firstname", 1);
            if (!firstname)
            {
                firstname_parameter = new SqlParameter("@firstname", Zero);
            }

            var name_parameter = new SqlParameter("@name", name);
            var result = await _context.Person.FromSqlRaw("sp_findPersonWithSameName @name,@firstname ", name_parameter, firstname_parameter).ToListAsync();

            var result_format = new List<int>();

            foreach (var l in result)
            {
                result_format.Add(l.GUID);
            }

            return result_format;
        }

    }
}
