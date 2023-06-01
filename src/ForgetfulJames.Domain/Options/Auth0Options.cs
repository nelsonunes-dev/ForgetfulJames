using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Domain.Options
{
    public class Auth0Options
    {
        public string Domain { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
    }
}
