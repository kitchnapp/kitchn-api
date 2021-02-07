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
	/// Implementation for accessing batteries
	/// </summary>
	public class BatteryRepository : IRepository<Battery>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored batteries
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// /// <param name="mapper">Mapper implementation</param>
		public BatteryRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Battery> AddAsync(Battery item)
		{
			if (item.Id != default)
				throw new ArgumentException("Battery ID cannot have a value");
			if (string.IsNullOrEmpty(item.Name))
				throw new ArgumentException("Battery name cannot be null");

			var dbBattery = _mapper.Map<Data.Models.Battery>(item);

			await _context.AddAsync(dbBattery);
			await _context.SaveChangesAsync();

			return _mapper.Map<Battery>(dbBattery);
		}

		/// <summary>
		/// Deletes the provided battery by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Battery item)
		{
			var battery = await _context.Batteries.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (battery == null)
				throw new Exception("Battery not found");

			_context.Remove(battery);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of batteries from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Battery>> GetAsync()
		{
			return _mapper.Map<IEnumerable<Battery>>(
				await _context.Batteries.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a battery in the database, provided an existing battery exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Battery> UpdateAsync(Battery item)
		{
			var dbBattery = await _context.Batteries
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbBattery == null)
				throw new Exception("Battery not found");

			var updatedDbBattery = _mapper.Map(item, dbBattery);

			_context.Batteries.Update(updatedDbBattery);
			await _context.SaveChangesAsync();

			return _mapper.Map<Battery>(updatedDbBattery);
		}
	}
}
