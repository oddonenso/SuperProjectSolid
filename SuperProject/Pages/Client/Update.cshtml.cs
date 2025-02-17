using Domain.Dto;
using Domain.Querry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using SuperProject.Model;
using System.Windows.Input;

namespace SuperProject.Pages.Client
{
    public class UpdateModel : PageModel
    {


        private readonly ICommand<UpdateClient> _command;
        private readonly IQueryService<IQuery, UserDTO> _query;
        [BindProperty]
        public UserInDb Input { get; set; }


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
    }
}
