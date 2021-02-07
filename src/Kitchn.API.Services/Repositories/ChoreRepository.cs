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
	/// Implementation for accessing chores
	/// </summary>
	public class ChoreRepository : IRepository<Chore>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored chores
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public ChoreRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Chore> AddAsync(Chore item)
		{
			if (item.Id != default)
				throw new ArgumentException("Chore ID cannot have a value");
			if (string.IsNullOrEmpty(item.Title))
				throw new ArgumentException("Chore title cannot be null");

			var dbChore = _mapper.Map<Data.Models.Chore>(item);

			await _context.AddAsync(dbChore);
			await _context.SaveChangesAsync();

			return _mapper.Map<Chore>(dbChore);
		}

		/// <summary>
		/// Deletes the provided chore by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Chore item)
		{
			var chore = await _context.Chores.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (chore == null)
				throw new Exception("Chore not found");

			_context.Remove(chore);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of chores from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Chore>> GetAsync()
		{
			return _mapper.Map<IEnumerable<Chore>>(
				await _context.Chores.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a chore in the database, provided an existing chore exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Chore> UpdateAsync(Chore item)
		{
			var dbChore = await _context.Chores
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbChore == null)
				throw new Exception("Chore not found");

			var updatedDbChore = _mapper.Map(item, dbChore);

			_context.Chores.Update(updatedDbChore);
			await _context.SaveChangesAsync();

			return _mapper.Map<Chore>(updatedDbChore);
		}
	}
}
