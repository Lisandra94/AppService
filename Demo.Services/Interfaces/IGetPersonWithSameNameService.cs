using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Services.Models;

namespace App.Services.Interfaces
{
    public interface IGetPersonWithSameNameService
    {
      
        Task<List<Guid>> GetPersonWithSameName(string name, bool firstname);
    }
   
}
