using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Services.DBContext;
using App.Services.Models;
using App.Services.Services;
using App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.WebRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFinforInsertService _appService;


        public IndexModel(ILogger<IndexModel> logger, IFinforInsertService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        public void OnGetAsync(int guid)
        {
            Guid = guid;
           
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }
        [BindProperty]
        public int Guid { get; set; }
        

        public async Task<IActionResult> OnPostAsync(PersonModel PersonModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {

                var Guid = await _appService.FindorInsertPerson(PersonModel);
                
                return await Task.FromResult(RedirectToPage("./Index", new { Guid = Guid }));

            }
        }

    }

}
