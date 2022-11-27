using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        PasswordManagerEntities context = new PasswordManagerEntities();

        PasswordManagerRepository<User> userRepository;
        PasswordManagerRepository<SocialMedia> socialMediaRepository;
        PasswordManagerRepository<Account> accountRepository;

        public PasswordManagerRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new PasswordManagerRepository<User>(context);
                return userRepository;
            }
        }

        public PasswordManagerRepository<SocialMedia> SocialMediaRepository
        {
            get
            {
                if (this.socialMediaRepository == null)
                    this.socialMediaRepository = new PasswordManagerRepository<SocialMedia>(context);
                return socialMediaRepository;
            }
        }

        public PasswordManagerRepository<Account> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                    this.accountRepository = new PasswordManagerRepository<Account>(context);
                return accountRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return context.Database.SqlQuery<T>(sql);
        }

        public virtual IEnumerable<T> SQLQueryWithParameters<T>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(sql, parameters);
        }

    }
}
