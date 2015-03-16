using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Security;
using AcessoCard.Business;
using AcessoCard.Models;
using AcessoCard.Service.WebApi.Filters;

namespace AcessoCard.Service.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {

        [HttpPost]
        [BasicAuth]
        [Route("api/Login")]
        public HttpResponseMessage Login()
        {
            try
            {
                if (User != null)
                {
                    var url = "http://localhost:4105/App/Index";
                    return Request.CreateResponse(HttpStatusCode.OK, url);
                }

                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                    "Usuário Inexistente");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao Logar-se");
            }
        }
 
        [HttpPost]
        [Route("api/recuperar")]
        public HttpResponseMessage RecuperarSenha(string email)
        {
            try
            {
                if (email == null)
                    return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Digite um email válido.");

                var senhaDescriptografada = new UserBus().RecuperarSenhaUsuario(email);

                if (senhaDescriptografada == null)
                    return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Usuário não localizado.");

                return Request.CreateResponse(HttpStatusCode.OK, senhaDescriptografada);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao recuperar sua senha.");
            }
        }

        [HttpPost]
        [Route("api/alterarSenha")]
        public HttpResponseMessage AlterarSenha(string email, string novaSenha, string senhaAntiga)
        {
            try
            {
                new UserBus().AlterarSenha(email, novaSenha, senhaAntiga);
                return Request.CreateResponse(HttpStatusCode.OK, "Senha Alterada com Sucesso !");

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao alterar sua senha.");

            }
        }

    }
}
