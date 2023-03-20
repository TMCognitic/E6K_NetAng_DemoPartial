using E6K_NetAng_DemoPartial.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6K_NetAng_DemoPartial.Models.Repository
{
    public interface IPaysRepository
    {
        IEnumerable<Pays> Get();
    }
}
