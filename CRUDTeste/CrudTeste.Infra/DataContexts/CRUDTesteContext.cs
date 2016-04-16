using CrudTeste.Domain;
using CrudTeste.Infra.Mappings;
using System;
using System.Data.Entity;

namespace CrudTeste.Infra.DataContexts
{
    public class CRUDTesteContext : DbContext
    {
        public CRUDTesteContext() 
            : base("CRUDTesteConnectionString")
        {
            //Database.SetInitializer<CRUDTesteContext>(new CRUDTesteContextInitializer());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Operadora> Operadoras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new OperadoraMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CRUDTesteContextInitializer : CreateDatabaseIfNotExists<CRUDTesteContext>
    {
        protected override void Seed(CRUDTesteContext context)
        {
            //Add categorias no banco de dados
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.Categories.Add(new Category { Id = 4, Title = "Operadora" });
            context.SaveChanges();

            //Add produtos no banco de dados
            context.Products.Add(new Product { Id = 1, IsActive = true, CategoryId = 1, AcquireDate = DateTime.Now, Price = 0.99m, Title = "Mouse" });
            context.Products.Add(new Product { Id = 2, IsActive = true, CategoryId = 1, AcquireDate = DateTime.Now, Price = 0.99m, Title = "Cabo HDMI" });
            context.Products.Add(new Product { Id = 3, IsActive = true, CategoryId = 1, AcquireDate = DateTime.Now, Price = 0.99m, Title = "Teclado" });

            context.Products.Add(new Product { Id = 4, IsActive = true, CategoryId = 2, AcquireDate = DateTime.Now, Price = 1.99m, Title = "Mario Bros" });
            context.Products.Add(new Product { Id = 5, IsActive = true, CategoryId = 2, AcquireDate = DateTime.Now, Price = 1.99m, Title = "Pitfall" });
            context.Products.Add(new Product { Id = 6, IsActive = true, CategoryId = 2, AcquireDate = DateTime.Now, Price = 1.99m, Title = "Pac Man" });

            context.Products.Add(new Product { Id = 7, IsActive = true, CategoryId = 3, AcquireDate = DateTime.Now, Price = 2.99m, Title = "Mouse" });
            context.Products.Add(new Product { Id = 8, IsActive = true, CategoryId = 3, AcquireDate = DateTime.Now, Price = 2.99m, Title = "Cabo HDMI" });
            context.Products.Add(new Product { Id = 9, IsActive = true, CategoryId = 3, AcquireDate = DateTime.Now, Price = 2.99m, Title = "Teclado" });
            context.SaveChanges();


            //Add operadoras no banco de dados
            context.Operadoras.Add(new Operadora { Id = 1, Codigo = 21, CategoryId = 4, Preco = 2.00m, Nome = "Embratel" });
            context.Operadoras.Add(new Operadora { Id = 2, Codigo = 25, CategoryId = 4, Preco = 1.99m, Nome = "GVT" });
            context.Operadoras.Add(new Operadora { Id = 3, Codigo = 14, CategoryId = 4, Preco = 2.00m, Nome = "OI" });
            context.Operadoras.Add(new Operadora { Id = 4, Codigo = 41, CategoryId = 4, Preco = 3.00m, Nome = "Tim" });
            context.Operadoras.Add(new Operadora { Id = 5, Codigo = 15, CategoryId = 4, Preco = 1.99m, Nome = "Vivo" });
            context.SaveChanges();

            //Add contatos no banco de dados
            context.Contatos.Add(new Contato { Id = 1, Data = DateTime.Now, OperadoraId = 5, Nome = "Felipe Santos", Telefone = "98268-2229" });
            context.Contatos.Add(new Contato { Id = 2, Data = DateTime.Now, OperadoraId = 1, Nome = "Isabella Fraga", Telefone = "97619-3559" });
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
