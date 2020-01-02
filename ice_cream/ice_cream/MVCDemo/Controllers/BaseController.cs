using ice_cream.Repositories.Sessions;
using Smooth.IoC.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ice_cream.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IDbFactory _dbFactory;

        public BaseController(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }
        protected ISession getSession()
            => _dbFactory.Create<IAppSession>();
    }
}