using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Helpers
{
    public class MessageDto<T>
    {
        public int Id { get; set; } = 0;
        public T Value { get; set; }
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
