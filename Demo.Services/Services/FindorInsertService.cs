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
   public class FindorInsertService : IFinforInsertService
    {
        private readonly AppDBContext _context;

        public FindorInsertService(AppDBContext context)
        {
            _context = context;

        }

        public async Task<int> FindorInsertPerson(PersonModel person)
        {
            var firstname_parameter = new SqlParameter("@_firstname", person.FirstName);
            var lastName_parameter = new SqlParameter("@_lastname", person.LastName);

            var result = await _context.Person.FromSqlRaw("sp_insertPersonIfnotExists @_firstname,@_lastname", firstname_parameter, lastName_parameter).ToListAsync();
            
            return await Task.FromResult(result[0].GUID);
        }

    }

   
}
