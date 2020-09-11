using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using App.Services.Interfaces;
using App.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.WebRazor.Pages
{
    public class SecondServiceModel : PageModel
    {
        private readonly ILogger<SecondServiceModel> _logger;
        private readonly IGetPersonWithSameNameService _appService2;
        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        public bool SearchForFirstName { get; set; }
        [BindProperty]
        public List<string> list_guid { get; set; }
        [BindProperty]
        public bool emptyResult { get; set; }




        public SecondServiceModel(ILogger<SecondServiceModel> logger, IGetPersonWithSameNameService appService)
        {
            _logger = logger;
            _appService2 = appService;
        }

        public void OnGetAsync(List<string> list, bool EmptyResult)
        {
            
            SearchForFirstName = true;
            list_guid = list;
            emptyResult = EmptyResult;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                try { 

                var list = await _appService2.GetPersonWithSameName(Name,SearchForFirstName);

                if (list.Count == 0)
                {
                    return await Task.FromResult(RedirectToPage("./SecondService", new { EmptyResult = true }));
                }
                else
                {
                    return await Task.FromResult(RedirectToPage("./SecondService", new { list = list, EmptyResult = false }));
                }

                }catch(Exception ex)
                {
                    // redirect to Error page if an error occurs
                    return await Task.FromResult(RedirectToPage("./Error", new { mess = ex })); 
                }

            }
        }
    }
}
