using Domain.Dto;
using Domain.Query;
using Service;


namespace Domain.Querry
{
    public class AllUserService : IQueryService<All, List<UserDTO>>
    {

        private IRepository _repository;

        public AllUserService(IRepository repository)
        {
            if(repository==null)
            {
                throw new ArgumentNullException();
            }
            _repository = repository;
        }
        public List<UserDTO> Execute(All obj)
        {
            return _repository.GetAll();
        }
    }


}
