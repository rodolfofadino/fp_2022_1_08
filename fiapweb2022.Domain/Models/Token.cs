using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb2022.Domain.Models
{
    public class TokenStore
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Used { get; set; }
        
    }
}
