



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ice_cream.Repositories.Sessions;
using Smooth.IoC.Repository.UnitOfWork;
using Smooth.IoC.UnitOfWork.Interfaces;
using ice_cream.Models;
using Dapper;
using Dapper.FastCrud;



namespace ice_cream.Repositories
{

    public interface IMapRepsitory : IRepository<Map, int>
    {

       

    }
    public class MapRepsitory : Repository<Map, int>, IMapRepsitory
    {
        public MapRepsitory(IDbFactory factory) : base(factory)
        {
        }

       


    }

}


    