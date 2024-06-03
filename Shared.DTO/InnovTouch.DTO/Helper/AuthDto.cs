using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Models.Helper
{
    public class AuthDto<T> where T : class
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string site { get; set; } = string.Empty;
        public T Data { get; set; }

        public override string ToString()
        {
            return $"UserName:{UserName}, site:{site}, Data:{typeof(T).Name}";
        }
    }
}
