using E6K_NetAng_DemoPartial.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6K_NetAng_DemoPartial.Models.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Pays ToPays(this IDataRecord dataRecord)
        {
            return new Pays()
            {
                Code = (string)dataRecord["Code"],
                Nom = (string)dataRecord["Nom"],
            };
        }

        internal static Ville ToVille(this IDataRecord dataRecord)
        {
            return new Ville()
            {
                Id = (int)dataRecord["Id"],
                CodePostal = (string)dataRecord["CodePostal"],
                Nom = (string)dataRecord["Nom"],
            };
        }
    }
}
