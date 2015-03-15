using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

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
            };

            var credenciais = Encoding.GetEncoding("UTF-8").GetString(
                Convert.FromBase64String(headersRequisicao.Parameter)).Split(':');

            var email = credenciais[0];
            var senha = credenciais[1];

            if (email == "erick.workspace@gmail.com" && senha == "123")
            {
                var principal = new GenericPrincipal(new GenericIdentity(email), null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
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

        private void LimparRecursos()
        {
            Thread.CurrentPrincipal = null;
            HttpContext.Current.User = null;
        }
    }
}