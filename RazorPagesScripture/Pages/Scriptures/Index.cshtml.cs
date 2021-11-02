using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesScripture.Models;

namespace RazorPagesScripture.Pages_Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesScriptureContext _context;

        public IndexModel(RazorPagesScriptureContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        public SelectList Entries { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from s in _context.Scripture
                                            orderby s.Book
                                            select s.Book;

            var scriptures = from s in _context.Scripture
                         select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Entry.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
