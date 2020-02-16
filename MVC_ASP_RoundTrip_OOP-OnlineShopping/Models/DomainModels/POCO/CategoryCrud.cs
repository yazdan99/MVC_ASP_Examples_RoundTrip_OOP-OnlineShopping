using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.POCO
{
    public class CategoryCrud
    {
        #region [- ctor -]
        public CategoryCrud()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<Category> Select()
        {
            using (var context = new Models.DomainModels.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    var q = context.Category.ToList();
                    return q;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Insert(Category category) -]
        public void Insert(Category category)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Category.Add(category);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

        }
        #endregion

        #region [- Find(int? id) -]
        public Category Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Category category = context.Category.Find(id);
                    return category;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Update(Category category) -]
        public void Update(Category category)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

        }
        #endregion

        #region [- Delete(int id) -]
        public void Delete(int id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Category ref_Category = new Category();
                    ref_Category = context.Category.Find(id);
                    context.Category.Remove(ref_Category);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

        }
        #endregion


        #endregion
    }
}