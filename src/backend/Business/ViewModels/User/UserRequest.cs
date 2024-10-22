using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.User
{
    public class UserRequest
    {
        public int IdUsu { get; set; }

        public string NomUsu { get; set; }
        public string CodAceUsu { get; set; }
        public string DesEmailUsu { get; set; }
        public string CodPerUsu { get; set; }
        public string IndStaReg { get; set; }

    }
}
