using CrudTeste.Domain;
using CrudTeste.Infra.DataContexts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDTeste.Api.Controllers
{
    public class ContatoController : ApiController
    {
        private CRUDTesteContext db = new CRUDTesteContext();

        #region Contatos
        [Route("api/contatos")]
        //Lista os contatos que foram inseridos na base, sem critérios.
        public HttpResponseMessage GetContatos()
        {
            var result = db.Contatos.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("api/contatos/{id}")]
        //Lista os contatos de acordo com o id que é digitado.
        public HttpResponseMessage GetContatos(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var result = db.Contatos.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível recuperar o contato");
        }

        [HttpPost]
        [Route("api/contatos")]
        //Cria um contato novo.
        public HttpResponseMessage PostContato(Contato contato)
        {
            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Contatos.Add(contato);
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o contato");
            }
        }

        [HttpPatch]
        [Route("api/contatos")]
        //Altera o contato.
        public HttpResponseMessage PatchContato(Contato contato)
        {
            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Contato>(contato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o contato");
            }
        }

        [HttpPut]
        [Route("api/contatos")]
        //Altera o contato.
        public HttpResponseMessage PutContato(Contato contato)
        {
            if (contato == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Contato>(contato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o contato");
            }
        }

        [HttpDelete]
        [Route("api/contatos")]
        //Deleta o contato.
        public HttpResponseMessage DeleteOperadora(int contatoId)
        {
            if (contatoId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Contatos.Remove(db.Contatos.Find(contatoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Contato excluído");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir o contato");
            }
        }
        #endregion        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
