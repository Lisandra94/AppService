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

        public void OnGetAsync(Guid guid, bool showMess)
        {
            Guid = guid;
            show_mess = showMess;
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }
        [BindProperty]
        public Guid Guid { get; set; }
        [BindProperty]
        public bool show_mess { get; set; }


        public async Task<IActionResult> OnPostAsync(PersonModel PersonModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                try
                {
                    var Guid = await _appService.FindorInsertPerson(PersonModel);

                    return await Task.FromResult(RedirectToPage("./Index", new { Guid = Guid, showMess = true }));
                }catch(Exception ex)
                {
                    // redirect to Error page if an error occurs
                    return await Task.FromResult(RedirectToPage("./Error", new { mess = ex }));
                }
              

            }
        }

    }

}
