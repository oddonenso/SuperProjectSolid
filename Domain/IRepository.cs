using Domain.Dto;
using SuperProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        void Create(UserDTO user);
        bool Check(string login);
        List<UserDTO> GetAll();
        UserDTO GetById(int id);
        bool Update(UpdateClient client);
    }
}
