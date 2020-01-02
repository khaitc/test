            using Dapper;
            using ice_cream.Models;
            using ice_cream.Repositories.Sessions;
            using Smooth.IoC.Repository.UnitOfWork;
            using Smooth.IoC.UnitOfWork.Interfaces;
            using System.Collections;
            using System.Collections.Generic;
            using System.Data;
            using System.Linq;

            namespace ice_cream.Repositories
            {
                public interface ICategoryRepository : IRepository<Category, int>
                {
                    bool IsExist(Category category);
                    IEnumerable<Category> Searching(string Search);
                    string count();
                    bool IsExistEdit(Category category, int id);
                    Category GetByName(string categoryName);


                }

                public class CategoryRepository : Repository<Category, int>, ICategoryRepository
                {
                    public CategoryRepository(IDbFactory factory) : base(factory)
                    {
                    }

                    public bool IsExist(Category category)
                    {
                        using (var session = Factory.Create<IAppSession>())
                        {
                            var sql = $"SELECT * FROM {Sql.Table<Category>()} WHERE {nameof(Category.CategoryName)}=N'{category.CategoryName}'";
                            var existItems = session.Query<Category>(sql);
                            return existItems.Count() > 0;
                        }
                    }
                    public IEnumerable<Category> Searching(string Search)
                    {
                        using (var session = Factory.Create<IAppSession>())
                        {
                            var sql = $"SELECT * FROM {Sql.Table<Category>()} WHERE {nameof(Category.CategoryName)} LIKE N'%{Search}%'  ORDER BY {nameof(Category.CategoryName)} ASC";
                            var search = session.Query<Category>(sql);
                            return search;
                        }

                    }
                    public string count()
                    {
                        using (var session = Factory.Create<IAppSession>())
                        {
                            var sql = $"SELECT COUNT({nameof(Category.CategoryId)}) FROM {Sql.Table<Category>()}";
                            var count = session.QueryFirst(sql);
                            return count;

                        }
                    }
                    public bool IsExistEdit(Category category, int id)
                    {
                        using (var session = Factory.Create<IAppSession>())
                        {
                            var sql = $"SELECT * FROM {Sql.Table<Category>()} WHERE {nameof(Category.CategoryName)}=N'{category.CategoryName}' AND {nameof(Category.CategoryId)}={id}";
                            var existItems = session.Query<Category>(sql);
                            if (existItems.Count() > 0)
                            {
                                return true;
                            }
                            else

                                return false;
                        }
                    }

                    public Category GetByName(string categoryName)
                    {
                        using (var session = Factory.Create<IAppSession>())
                        {
                            var sql = $"SELECT * FROM {Sql.Table<Category>()} WHERE {nameof(Category.CategoryName)}=N'{categoryName}'";
                            return session.Query<Category>(sql).FirstOrDefault();
                        }
                    }
                }
            }