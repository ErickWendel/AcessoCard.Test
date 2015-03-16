using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using AcessoCard.Business;
using AcessoCard.Models;

namespace AcessoCard.Service.WebApi.Filters
{
    public class BasicAuthAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headersRequisicao = actionContext.Request.Headers.Authorization;
            if (!ValidarRequisicao(headersRequisicao))
            {
                LimparRecursos();
                return;
            }

            var credenciais = Encoding.GetEncoding("UTF-8").GetString(
                Convert.FromBase64String(headersRequisicao.Parameter)).Split(':');

            var usuario = new UserMod {Email = credenciais[0], Senha = credenciais[1]};

            var usuarioDb = new UserBus().VerificarUsuario(usuario);
            if (usuarioDb != null)
            {
                var principal = new GenericPrincipal(new GenericIdentity(usuarioDb.Id.ToString()), null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
                //FormsAuthentication.SetAuthCookie(usuarioDb.Id.ToString(), false);

            }
            else
                LimparRecursos();

            base.OnAuthorization(actionContext);
        }

        private bool ValidarRequisicao(AuthenticationHeaderValue headersRequisicao)
        {
            if (headersRequisicao == null)
               return false;

            if (!headersRequisicao.Scheme.Equals("Basic"))
                return false;

            if (String.IsNullOrEmpty(headersRequisicao.Parameter))
                return false;

            return true;
        }

        private static void LimparRecursos()
        {
            //FormsAuthentication.SignOut();
            Thread.CurrentPrincipal = null;
            HttpContext.Current.User = null;
        }
    }
}