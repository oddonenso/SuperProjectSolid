using Domain.Dto;
using Domain.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using SuperProject.Model;

namespace SuperProject.Pages.Client
{
    public class ShowModel : PageModel
    {
        private readonly IQueryService<All, List<UserDTO>> _getAll;

        public ShowModel(IQueryService<All, List<UserDTO>> getAll)
        {
            ArgumentNullException.ThrowIfNull(getAll);
            _getAll = getAll;
        }

        [BindProperty]
        public List<UserInDb> AllUser { get; set; }

        public void OnGet()
        {

        }
    }
}
