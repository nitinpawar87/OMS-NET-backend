using PMS_RepositoryPattern.Data;
using PMS_RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_RepositoryPattern.Service
{
    public class UserRepository : IUserRepository
    {
        ProductDBContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public UserRepository(ProductDBContext _context)
        {
            try
            {
                this._context = _context;
            }
            catch 
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string userName, string password)
        {
            try
            {
                User user = _context.Users.Where(user => user.UserName.ToLower() == userName.ToLower() && user.Password == password).FirstOrDefault();
                if (user != null)
                {
                    user.IsLoggedIn = true;
                    _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return _context.Users.Where(user => user.UserName.ToLower() == userName.ToLower() && user.Password == password).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _context.Users;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void LogoutUser(int Id)
        {
            try
            {
                User user = _context.Users.Where(user => user.Id == Id).FirstOrDefault();
                if (user != null)
                {
                    user.IsLoggedIn = false;
                    _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUser(int Id)
        {
            try
            {
                return _context.Users.Where(user => user.Id == Id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
