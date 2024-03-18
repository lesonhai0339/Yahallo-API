using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.ResponeTypes
{
    public class LoginRespone
    {
        public LoginRespone() { }
        public LoginRespone(
            string id, 
            string accesstoken,
            string refeshtoken)
        { 
            Id= id;
            AccessToken = accesstoken;
            RefeshToken = refeshtoken;  
        }
        public string Id { get; set; } = null!;
        public string AccessToken { get; set; }= null!;
        public string RefeshToken { get; set; } = null!;
    }
}
