using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models
{
    public abstract class BaseModel
    {
        public bool IsDeleted { get; set; } = false;
    }
}
