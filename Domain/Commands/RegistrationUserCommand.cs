using Domain.Dto;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class RegistrationUserCommand : ICommand<UserDTO>
    {
        private readonly IRepository _repository;
        public RegistrationUserCommand(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }
            _repository = repository;
        }

        public void Execute(UserDTO obj)
        {
            if(obj.Login.Length<3||obj.Password.Length<3)
            {
                return;
            }
            if(_repository.Check(obj.Login))
            {
                _repository.Create(obj);
            }
        }
    }
}
