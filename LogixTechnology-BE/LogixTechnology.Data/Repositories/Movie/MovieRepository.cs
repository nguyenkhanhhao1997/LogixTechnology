using LogixTechnology.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogixTechnology.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        /// <summary>
        /// EFDataContext
        /// </summary>
        public EFDataContext _db;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public MovieRepository(EFDataContext db) {
            this._db = db;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>status</returns>
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies =  await this._db.Movies.ToListAsync();
            return movies;
        }
    }
}
