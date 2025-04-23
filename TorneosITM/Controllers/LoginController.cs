using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorneosITM.Classes;
using static TorneosITM.Models.libLogin;

namespace TorneosITM.Controllers
{
        [RoutePrefix("api/Login")]
        public class LoginController : ApiController
        {
            [HttpPost]
            [Route("Autenticar")]
            public IQueryable<LoginRespuesta> Ingresar(Login login)
            {
                clsLogin _Login = new clsLogin();
                _Login.login = login;
                return _Login.Ingresar();
            }
        }
    }