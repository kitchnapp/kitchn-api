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
	/// Implementation for accessing measurements
	/// </summary>
	public class MeasurementRepository : IRepository<Measurement>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored measurements
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public MeasurementRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Measurement> AddAsync(Measurement item)
		{
			if (item.Id != default)
				throw new ArgumentException("Measurement ID cannot have a value");
			if (string.IsNullOrEmpty(item.Name))
				throw new ArgumentException("Measurement name cannot be null");

			var dbMeasurement = _mapper.Map<Data.Models.Measurement>(item);

			await _context.AddAsync(dbMeasurement);
			await _context.SaveChangesAsync();

			return _mapper.Map<Measurement>(dbMeasurement);
		}

		/// <summary>
		/// Deletes the provided measurement by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Measurement item)
		{
			var measurement = await _context.Measurements.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (measurement == null)
				throw new Exception("Measurement not found");

			_context.Remove(measurement);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of measurements from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Measurement>> GetAsync()
		{
			return _mapper.Map<IEnumerable<Measurement>>(
				await _context.Measurements.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a measurement in the database, provided an existing measurement exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Measurement> UpdateAsync(Measurement item)
		{
			var dbMeasurement = await _context.Measurements
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbMeasurement == null)
				throw new Exception("Measurement not found");

			var updatedDbMeasurement = _mapper.Map(item, dbMeasurement);

			_context.Measurements.Update(updatedDbMeasurement);
			await _context.SaveChangesAsync();

			return _mapper.Map<Measurement>(updatedDbMeasurement);
		}
	}
}
