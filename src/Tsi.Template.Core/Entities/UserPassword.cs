using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Core.Entities
{
    public class UserPassword: BaseEntity, ICommonEntity
    { 
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UserId { get; set; } 
    }
}
