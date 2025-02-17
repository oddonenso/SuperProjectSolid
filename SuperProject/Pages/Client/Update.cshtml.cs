using Domain.Dto;
using Domain.Querry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using SuperProject.Model;
using System.Windows.Input;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperProject.Pages.Client
{
    public class UpdateModel : PageModel
    {


        private readonly ICommand<UpdateClient> _command;
        private readonly IQueryService<IQuery, UserDTO> _query;
        [BindProperty]
        public UserInDb Input { get; set; }
        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("Россия", "Россия"),
            new SelectListItem("США", "США"),
            new SelectListItem("Китай", "Китай"),
            new SelectListItem("Мексика", "Мексика"),
            new SelectListItem("Канада", "Канада"),
        };

        public UpdateModel(ICommand<UpdateClient> command, IQueryService<IQuery, UserDTO> query)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));
            if(query == null) throw new ArgumentNullException(nameof(query));
            _command = command;
            _query = query;
        }

        public void OnGet(int id)
        {
            SearchById searchById = new SearchById();
            searchById.id = id;
             var user = _query.Execute(searchById);
            if(user != null)
            {
                Input = new UserInDb();
                Input.Id = user.Id;
                Input.Name = user.Login;
                Input.Password = user.Password;
                Input.PasswordAgain = user.Password;
                Input.Country = user.Country;
            }
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            UpdateClient updateClient = new UpdateClient();
            updateClient.Id = Input.Id;
            updateClient.Password = Input.Password;
            updateClient.Country = Input.Country;
            try
            {
                _command.Execute(updateClient);
                
            }
            catch (MissingFieldException error)
            {

            }
            catch(InvalidDataException error)
            {
                return Page();
            }
            return RedirectToPage("/Client/Show");
        }
    }
}
