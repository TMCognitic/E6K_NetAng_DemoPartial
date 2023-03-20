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
    public class PaysService : IPaysRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaysService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Pays> Get()
        {
            return _dbConnection.ExecuteReader("SELECT Code, Nom FROM Pays;", (dr) => dr.ToPays());
        }
    }
}
