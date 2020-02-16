using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.POCO
{
    public class ProductCrud
    {
        #region [- ctor -]
        public ProductCrud()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<Product> Select()
        {
            using (var context = new Models.DomainModels.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    var product = context.Product.Include(p => p.Category).ToList();
                    return product;
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

        #region [- Insert(Product product) -]
        public void Insert(Product product)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Product.Add(product);
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
        public Product Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            //using ( OnlineShoppingEntities context = new OnlineShoppingEntities())
            {
                try
                {
                    Product product = context.Product.Find(id);
                    return product;
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

        #region [- Update(Product product) -]
        public void Update(Product product)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(product).State = EntityState.Modified;
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
                    Product ref_Product = new Product();
                    ref_Product = context.Product.Find(id);
                    context.Product.Remove(ref_Product);
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