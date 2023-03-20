using E6K_NetAng_DemoPartial.Models.Entities;
using E6K_NetAng_DemoPartial.Models.Mappers;
using E6K_NetAng_DemoPartial.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;

namespace E6K_NetAng_DemoPartial.Models.Services
{
    public class VilleService : IVilleRepository
    {
        private readonly IDbConnection _dbConnection;

        public VilleService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Ville> Get(string codePays)
        {
            return _dbConnection.ExecuteReader("SELECT Id, CodePostal, Nom FROM Ville WHERE CodePays = @CodePays", (dr) => dr.ToVille(), parameters: new { CodePays = codePays });
        }
    }
}
