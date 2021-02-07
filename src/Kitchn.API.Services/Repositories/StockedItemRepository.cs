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
	/// Implementation for accessing stocked items
	/// </summary>
	public class StockedItemRepository : IRepository<StockedItem>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored stocked items
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public StockedItemRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<StockedItem> AddAsync(StockedItem item)
		{
			if (item.Id != default)
				throw new ArgumentException("Stocked Item ID cannot have a value");
			if (item.ProductId == default)
				throw new ArgumentException("Stocked Item's product cannot be null");
			if (item.LocationId == default)
				throw new ArgumentException("Stocked Item's location cannot be null");

			var dbStockedItem = _mapper.Map<Data.Models.StockedItem>(item);

			await _context.AddAsync(dbStockedItem);
			await _context.SaveChangesAsync();

			return _mapper.Map<StockedItem>(dbStockedItem);
		}

		/// <summary>
		/// Deletes the provided stocked item by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(StockedItem item)
		{
			var stockedItem = await _context.StockedItems.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (stockedItem == null)
				throw new Exception("Stocked item not found");

			_context.Remove(stockedItem);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of stocked items from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<StockedItem>> GetAsync()
		{
			return _mapper.Map<IEnumerable<StockedItem>>(
				await _context.StockedItems.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a stocked item in the database, provided an existing stocked item exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<StockedItem> UpdateAsync(StockedItem item)
		{
			var dbStockedItem = await _context.StockedItems
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbStockedItem == null)
				throw new Exception("Stocked item not found");

			var updatedDbStockedItem = _mapper.Map(item, dbStockedItem);

			_context.StockedItems.Update(updatedDbStockedItem);
			await _context.SaveChangesAsync();

			return _mapper.Map<StockedItem>(updatedDbStockedItem);
		}
	}
}
