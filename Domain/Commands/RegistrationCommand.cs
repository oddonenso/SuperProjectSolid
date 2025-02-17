using Domain.Dto;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domain.Commands
{
    public class RegistrationCommand : ICommand<UserDTO>
    {
        public void Execute(UserDTO obj)
        {
            using(var stream = new StreamWriter(@"c:\1\reg.txt", true))
            {
                stream.WriteLine($"{obj.Login} {obj.Password} {obj.Country}");
            }
        }
    }
}
