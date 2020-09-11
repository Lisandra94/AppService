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

        public async Task<Guid> FindorInsertPerson(PersonModel person)
        {
            var firstname_parameter = new SqlParameter("@_firstname", person.FirstName);
            var lastName_parameter = new SqlParameter("@_lastname", person.LastName);

            Guid g = Guid.NewGuid();

            var guid_parameter = new SqlParameter("@_guid", g);

            try
            {
                var result = await _context.Person.FromSqlRaw("sp_insertPersonIfnotExists @_firstname,@_lastname,@_guid", firstname_parameter, lastName_parameter, guid_parameter).ToListAsync();

                return await Task.FromResult(result[0].GUID);
            }
            catch(Exception )
            {
                //add error handling
                throw new Exception("Error in the execution of the stored procedure sp_insertPersonIfnotExists");
            }
                
            }
                
        }

    }

