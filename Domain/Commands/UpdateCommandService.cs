using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain.Dto;
using SuperProject.Model;
namespace Domain.Commands
{
    public class UpdateCommandService : ICommand<UpdateClient>
    {
        private readonly IRepository _repository;

        public UpdateCommandService(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }
            _repository = repository;
        }

        public void Execute(UpdateClient obj)
        {
            if(!obj.isValidation)
            {
                throw new MissingFieldException();
            }
            if(!_repository.Update(obj))
            {
                throw new InvalidDataException();
            }
        }
    }
}
