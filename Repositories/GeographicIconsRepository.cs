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
    public interface IGeographicIconsRepository : IGenericRepository<GeographicIcon>
    {
        Task<List<GeographicIcon>> GetByName(string name);
        Task<List<GeographicIcon>> GetAllByDate(DateTime date);
        Task<List<GeographicIcon>> GetByCity(int idCity);
    }

    public class GeographicIconsRepository : GenericRepository<GeographicIcon>, IGeographicIconsRepository
    {
        private readonly GeographicIconsDbContext _context;

        public GeographicIconsRepository(GeographicIconsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GeographicIcon>> GetByName(string name)
        {
            if (name == string.Empty)
            {
                throw new Exception("Su ícono no ha sido escrito");
            }
            try
            {
                var icons = await _context.GeographicIcons.Where(icon => icon.Name == name).ToListAsync();

                return icons;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<GeographicIcon>> GetAllByDate(DateTime date)
        {
            try
            {
                var icons = await (from icon in _context.GeographicIcons
                                   where icon.CreationDate.Date == date
                                   orderby icon.CreationDate.Date descending
                                   select icon).ToListAsync();
                return icons;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<GeographicIcon>> GetByCity(int cityId)
        {
            try
            {
                var icons = await (from icon in _context.GeographicIcons
                                   where icon.City.CityId == cityId
                                   select icon).ToListAsync();
                return icons;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

