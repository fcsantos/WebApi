using CrudTeste.Domain;
using CrudTeste.Infra.DataContexts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDTeste.Api.Controllers
{
    public class OperadoraController : ApiController
    {
        private CRUDTesteContext db = new CRUDTesteContext();

        #region Operadoras
        [Route("api/operadoras")]
        //Lista as operadoras que foram inseridas na base, sem critérios.
        public HttpResponseMessage GetOperadoras()
        {
            var result = db.Operadoras.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("api/operadoras/{id}")]
        //Lista as operadoras de acordo com o id que é digitado.
        public HttpResponseMessage GetOperadoras(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var result = db.Operadoras.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível recuperar a operadora");
        }

        [HttpPost]
        [Route("api/operadoras")]
        //Cria uma operadora nova.
        public HttpResponseMessage PostOperadora(Operadora operadora)
        {
            if (operadora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Operadoras.Add(operadora);
                db.SaveChanges();

                var result = operadora;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir a operadora");
            }
        }

        [HttpPatch]
        [Route("api/operadoras")]
        //Altera a operadora.
        public HttpResponseMessage PatchOperadora(Operadora operadora)
        {
            if (operadora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Operadora>(operadora).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = operadora;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar a operadora");
            }
        }

        [HttpPut]
        [Route("api/operadoras")]
        //Altera a operadora.
        public HttpResponseMessage PutOperadora(Operadora operadora)
        {
            if (operadora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Operadora>(operadora).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = operadora;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar a operadora");
            }
        }

        [HttpDelete]
        [Route("api/operadoras")]
        //Deleta a operadora.
        public HttpResponseMessage DeleteOperadora(int operadoraId)
        {
            if (operadoraId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Operadoras.Remove(db.Operadoras.Find(operadoraId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Operadora excluída");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir a operadora");
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
