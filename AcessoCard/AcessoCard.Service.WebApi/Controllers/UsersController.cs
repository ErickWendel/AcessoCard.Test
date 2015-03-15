using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AcessoCard.Service.WebApi.Filters;

namespace AcessoCard.Service.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [BasicAuth]
        [Route("api/Login")]
        public HttpResponseMessage Login()
        {
            if (User != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    String.Format("{0} : {1}", "Usuario Logado", User.Identity.Name));
            }

            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, 
                "Usuário Inexistente");
        }
    }
}
