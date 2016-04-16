using CrudTeste.Domain;
using CrudTeste.Infra.DataContexts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDTeste.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private CRUDTesteContext db = new CRUDTesteContext();

        #region Categories
        [Route("api/categories")]
        //Lista todas as categorias.
        public HttpResponseMessage GetCategories()
        {
            var result = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("api/categories/{categoryId}/products")]
        //Lista os proditos por categoria.
        public HttpResponseMessage GetProductsByCategory(int categoryId)
        {
            var result = db.Products.Where(x => x.CategoryId == categoryId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/categories")]
        //Cria a categoria.
        public HttpResponseMessage PostCategory(Category category)
        {
            if (category == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Categories.Add(category);
                db.SaveChanges();

                var result = category;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir categoria");
            }
        }

        [HttpPatch]
        [Route("api/categories")]
        //Altera a categoria.
        public HttpResponseMessage PatchCategory(Category category)
        {
            if (category == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Category>(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = category;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar categoria");
            }
        }

        [HttpPut]
        [Route("api/categories")]
        //Altera a categoria.
        public HttpResponseMessage PutCategory(Category category)
        {
            if (category == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Category>(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = category;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar categoria");
            }
        }

        [HttpDelete]
        [Route("api/categories")]
        //Deleta a categoria.
        public HttpResponseMessage DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Categories.Remove(db.Categories.Find(categoryId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Categoria excluida");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir categoria");
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
