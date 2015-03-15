using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AcessoCard.Business;
using AcessoCard.Models;

namespace AcessoCard.Service.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppController : ApiController
    {
        [HttpGet]
        [Route("api/Listar")]
        public IEnumerable<ContatoMod> Listar()
        {
            try
            {
                var list = new ContatoBus().Listar();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/Cadastrar")]
        public HttpResponseMessage Cadastrar(ContatoMod dadosTela)
        {
            try
            {
                if (!ModelState.IsValid || dadosTela == null)
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed,
                        "Todos os Campos são Obrigatorios!");

                new ContatoBus().Cadastrar(dadosTela);
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao Cadastrar!");

            }
        }

        [HttpDelete]
        [Route("api/Deletar")]
        public HttpResponseMessage Deletar(Int32 id)
        {
            try
            {
                new ContatoBus().Deletar(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deletado com sucesso!");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao Deletar!");

            }
        }

        [HttpPut]
        [Route("api/Atualizar")]
        public HttpResponseMessage Atualizar(ContatoMod dadosTela)
        {
            try
            {
                if (!ModelState.IsValid || dadosTela == null)
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed,
                        "Todos os Campos são Obrigatorios!");

                new ContatoBus().Atualizar(dadosTela);
                return Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao Atualizar!");

            }
        }
    }
}
