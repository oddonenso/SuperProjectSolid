using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using SuperProject.Model;

namespace SuperProject.Pages.Client
{
    public class AddModel : PageModel
    {
        private readonly ICommand<UserDTO> _save;
        public AddModel(ICommand<UserDTO> save)
        {
            if(save ==null) throw new ArgumentNullException(nameof(save));
            _save = save;
        }

        [BindProperty]
        public User Input { get; set; } = null!;
        public IEnumerable<SelectListItem> SelectCountry { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("Россия", "Россия"),
            new SelectListItem("США", "США"),
            new SelectListItem("Китай", "Китай"),
            new SelectListItem("Мексика", "Мексика"),
            new SelectListItem("Канада", "Канада"),
        };
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _save.Execute(new UserDTO()
                {
                    Login = Input.Name,
                    Password = Input.Password,
                    Country = Input.Country,
                });
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
