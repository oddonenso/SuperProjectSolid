using Domain.Dto;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Querry
{
    public class GetUserByIdQuery : IQueryService<SearchById, UserDTO>
    {
        private readonly IRepository _repository;

        public GetUserByIdQuery(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public UserDTO Execute(SearchById obj)
        {
            //прикол
            if(obj.id<=0)
            {
                return null;
            }
          return _repository.GetById(obj.id);
        }
    }
}
