using CrudTeste.Domain;
using CrudTeste.Infra.DataContexts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDTeste.Api.Controllers
{
    public class ProductController : ApiController
    {
        private CRUDTesteContext db = new CRUDTesteContext();

        #region Products
        [Route("api/products")]
        //Lista os produtos que foram inseridos na base, sem critérios.
        public HttpResponseMessage GetProducts()
        {
            var result = db.Products.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("api/products/{id}")]
        //Lista os produtos de acordo com o id que é digitado.
        public HttpResponseMessage GetProducts(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var result = db.Products.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível recuperar o produto");
        }

        [HttpPost]
        [Route("api/products")]
        //Cria um produto novo.
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
            }
        }

        [HttpPatch]
        [Route("api/products")]
        //Altera o produto.
        public HttpResponseMessage PatchProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpPut]
        [Route("api/products")]
        //Altera o produto.
        public HttpResponseMessage PutProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpDelete]
        [Route("api/products")]
        //Deleta o produto.
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Products.Remove(db.Products.Find(productId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
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
