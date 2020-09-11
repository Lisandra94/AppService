using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Services.Models;

namespace App.Services.Interfaces
{
    public interface IAppService
    {
        Task<int> FindorInsertPerson(PersonModel person);

        Task<List<int>> GetPersonWithSameName(string name, bool firstname);
    }
}
