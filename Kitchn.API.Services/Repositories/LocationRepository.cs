using AutoMapper;
using Kitchn.API.Data;
using Kitchn.API.Services.Interfaces;
using Kitchn.API.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchn.API.Services.Repositories
{
	/// <summary>
	/// Implementation for accessing locations
	/// </summary>
	public class LocationRepository : IRepository<Location>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored locations
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public LocationRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Location> AddAsync(Location item)
		{
			if (item.Id != default)
				throw new ArgumentException("Location ID cannot have a value");
			if (string.IsNullOrEmpty(item.Name))
				throw new ArgumentException("Location name cannot be null");

			var dbLocation = _mapper.Map<Data.Models.Location>(item);

			await _context.AddAsync(dbLocation);
			await _context.SaveChangesAsync();

			return _mapper.Map<Location>(dbLocation);
		}

		/// <summary>
		/// Deletes the provided location by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Location item)
		{
			var location = await _context.Locations.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (location == null)
				throw new Exception("Location not found");

			_context.Remove(location);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of locations from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Location>> GetAsync()
		{
			return _mapper.Map<IEnumerable<Location>>(
				await _context.Locations.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a location in the database, provided an existing location exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Location> UpdateAsync(Location item)
		{
			var dbLocation = await _context.Locations
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbLocation == null)
				throw new Exception("Location not found");

			var updatedDbLocation = _mapper.Map(item, dbLocation);

			_context.Locations.Update(updatedDbLocation);
			await _context.SaveChangesAsync();

			return _mapper.Map<Location>(updatedDbLocation);
		}
	}
}
