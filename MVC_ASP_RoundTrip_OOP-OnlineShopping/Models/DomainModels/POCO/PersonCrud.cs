using MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_ASP_RoundTrip_OOP_OnlineShopping.Models.DomainModels.POCO
{
    public class PersonCrud
    {
        #region [- ctor -]
        public PersonCrud()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<Person> Select()
        {
            using (var context = new Models.DomainModels.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    var q = context.Person.ToList();
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

        #region [- Insert(Person person) -]
        public void Insert(Person person)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Person.Add(person);
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
        public Person Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Person person = context.Person.Find(id);
                    return person;
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

        #region [- Update(Person person) -]
        public void Update(Person person)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(person).State = EntityState.Modified;
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
                    Person ref_Person = new Person();
                    ref_Person = context.Person.Find(id);
                    context.Person.Remove(ref_Person);
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