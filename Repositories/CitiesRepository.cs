using ChallengeAlternativo.Data;
using ChallengeAlternativo.Models;
using ChallengeAlternativo.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlternativo.Repositories
{
    public interface ICitiesRepository : IGenericRepository<City>
    {
        Task<List<City>> GetByName(string name);
        Task<List<City>> GetByContinent(int continentId);
        Task<List<City>> GetOrdered(string order);
    }
    public class CitiesRepository : GenericRepository<City>, ICitiesRepository
    {
        private readonly GeographicIconsDbContext _context;

        public CitiesRepository(GeographicIconsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<City>> GetByContinent(int continentId)
        {

            var city = await _context.Cities.Where(c => c.ContinentId == continentId).ToListAsync();

            return city;

        }

        public async Task<List<City>> GetByName(string name)
        {
            if (name == string.Empty)
            {
                throw new Exception("Su ícono no ha sido escrito");
            }
            try
            {
                var cities = await _context.Cities.Where(city => city.Name == name).ToListAsync();

                return cities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<City>> GetOrdered(string order)
        {
            try
            {
                var cities = new List<City>();
                if (order == "ASC")
                    cities = await (from c in _context.Cities
                                    orderby c.Name ascending
                                    select c).ToListAsync();
                if (order == "DESC")
                    cities = await (from c in _context.Cities
                                    orderby c.Name descending
                                    select c).ToListAsync();

                return cities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
