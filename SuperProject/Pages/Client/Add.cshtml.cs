using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperProject.Model;

namespace SuperProject.Pages.Client
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public User Input { get; set; } = null!;
        public IEnumerable<SelectListItem> SelectCountry { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("������", "������"),
            new SelectListItem("���", "���"),
            new SelectListItem("�����", "�����"),
            new SelectListItem("�������", "�������"),
            new SelectListItem("������", "������"),
        };
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                //��� ������-������
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
