using LogixTechnology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogixTechnology.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// EFDataContext
        /// </summary>
        public EFDataContext _db;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public UserRepository(EFDataContext db) {
            this._db = db;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>status</returns>
        public async Task<bool> Register(UserInput userInput)
        {
            var check = this._db.Users.Any(s => s.UserName.ToLower() == userInput.UserName.ToLower());
            if(check)
            {
                return false;
            }
            var user = new User
            {
                UserName = userInput.UserName,
                Password = GetMD5(userInput.Password),
            };

            this._db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;

        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>status</returns>
        public async Task<User> GetUser(UserInput userInput)
        {
            var password = GetMD5(userInput.Password);
            var user = this._db.Users.Where(s => s.UserName == userInput.UserName && s.Password == password).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// GetMD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
