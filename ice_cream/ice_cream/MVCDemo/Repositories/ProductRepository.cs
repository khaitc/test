using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ice_cream.Repositories.Sessions;
using Smooth.IoC.Repository.UnitOfWork;
using Smooth.IoC.UnitOfWork.Interfaces;
using ice_cream.Models;
using Dapper;
using Dapper.FastCrud;



namespace ice_cream.Repositories
{

    public interface IProductRepository : IRepository<Product, int>
    {

        IEnumerable<Product> Getjoin();
        IEnumerable<Category> GetNameCategory();
        IEnumerable<Category> GetIdCategory(int id);
        IEnumerable<Product> SearchSp(string Search, int CategoryId, int SupplierID);
        bool IsExist(Product product);
        Product GetByIdSp(int id);
        IEnumerable<Suppliers> GetNameSuppliers();

    }
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IDbFactory factory) : base(factory)
        {
        }

        public IEnumerable<Product> Getjoin()
        {
            using (var session = Factory.Create<IAppSession>())
            {
                //var sql = $"select * FROM {Sql.Table<Category>()} JOIN {Sql.Table<Product>()} ON {Sql.Table<Category>()}.{nameof(Category.CategoryId)}= {Sql.Table<Product>()}.{nameof(Product.CategoryId)} ORDER BY {Sql.Table<Product>()}.{nameof(Product.ProductID)} ASC ";
                //var query = session.Query<Product>(sql);
                //return query;
                return session.Find<Product>(stm => stm.Include<Category>(join => join.InnerJoin()).Include<Suppliers>(join => join.InnerJoin()));

            }

        }
        public IEnumerable<Category> GetNameCategory()
        {
            using (var session = Factory.Create<IAppSession>())
            {
                var sql = $"select * FROM {Sql.Table<Category>()}";
                var query = session.Query<Category>(sql);
                return query;

            }

        }

        public IEnumerable<Category> GetIdCategory(int id)
        {
            using (var session = Factory.Create<IAppSession>())
            {
                var sql = $"select * FROM {Sql.Table<Category>()} WHERE {nameof(Category.CategoryId)}={id}";
                var query = session.Query<Category>(sql);
                return query;

            }

        }
        public IEnumerable<Product> SearchSp(string Search, int CategoryId, int SupplierID)
        {
            using (var session = Factory.Create<IAppSession>())
            {
                var condition = $"{Sql.Table<Product>()}.{nameof(Product.ProductName)} LIKE N'%{Search}%'";
                //int conVertCategoryId = Convert.ToInt32(CategoryId);
                //int conVertSupplierId = Convert.ToInt32(SupplierID);
                if (CategoryId > 0)
                {
                    condition += $" AND {Sql.Table<Product>()}.{nameof(Product.CategoryId)} = {CategoryId}";
                }

                if (SupplierID > 0)
                {
                    condition += $" AND {Sql.Table<Product>()}.{nameof(Product.SupplierID)} = {SupplierID}";
                }
               

                return session.Find<Product>(stm => stm.Include<Category>(join => join.InnerJoin()).Include<Suppliers>(join => join.InnerJoin()).Where($"{condition}"));

            }
        }


        public bool IsExist(Product product)
        {

            using (var session = Factory.Create<IAppSession>())
            {
                var sql = $"select * FROM {Sql.Table<Product>()} WHERE {nameof(Product.ProductName)}=N'{product.ProductName}'AND {nameof(Product.CategoryId)}={product.CategoryId}";
                var query = session.Query<Product>(sql);
                return query.Count() > 0;
            }

        }
            public Product GetByIdSp(int id)
            {
                using (var session = Factory.Create<IAppSession>())
                {
                    return session.Find<Product>(stm => stm.Include<Category>(join => join.InnerJoin().Where($"{Sql.Table<Product>()}.{nameof(Product.ProductID)}={id}"))).FirstOrDefault();
                }
            }
        public IEnumerable<Suppliers> GetNameSuppliers()
        {
            using (var session = Factory.Create<IAppSession>())
            {
                var sql = $"select * FROM {Sql.Table<Suppliers>()}";
                var query = session.Query<Suppliers>(sql);
                return query;

            }

        }


    }

}