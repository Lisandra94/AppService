﻿using System;
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

        public async Task<List<Guid>> GetPersonWithSameName(string name, bool firstname)
        {
            try
            {
                var firstname_parameter = new SqlParameter("@firstname", 1);
                if (!firstname)
                {
                    firstname_parameter = new SqlParameter("@firstname", Zero);
                }

                var name_parameter = new SqlParameter("@name", name);

                var result = await _context.Person.FromSqlRaw("sp_findPersonWithSameName @name,@firstname ", name_parameter, firstname_parameter).ToListAsync();

                var result_format = new List<Guid>();

                foreach (var l in result)
                {
                    result_format.Add(l.GUID);
                }

                return result_format;
            }
            catch (Exception)
            {
                //add error handling
                throw new Exception("Error in the execution of the stored procedure sp_findPersonWithSameName");
            }
        }

    }
}
