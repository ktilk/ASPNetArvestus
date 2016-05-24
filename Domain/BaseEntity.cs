using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IBaseEntity
    {
        DateTime CreatedAtDT { get; set; }
        DateTime ModifiedAtDT { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        public DateTime CreatedAtDT { get; set; }

        public DateTime ModifiedAtDT { get; set; }
    }
}
