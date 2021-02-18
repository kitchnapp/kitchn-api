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
	/// Implementation for accessing recipe categories
	/// </summary>
	public class RecipeCategoryRepository : IRepository<RecipeCategory>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored recipe categories
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public RecipeCategoryRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<RecipeCategory> AddAsync(RecipeCategory item)
		{
			if (item.Id != default)
				throw new ArgumentException("Recipe category ID cannot have a value");
			if (string.IsNullOrEmpty(item.Name))
				throw new ArgumentException("Recipe category name cannot be null");

			var dbRecipeCategory = _mapper.Map<Data.Models.RecipeCategory>(item);

			await _context.AddAsync(dbRecipeCategory);
			await _context.SaveChangesAsync();

			return _mapper.Map<RecipeCategory>(dbRecipeCategory);
		}

		/// <summary>
		/// Deletes the provided recipe category by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(RecipeCategory item)
		{
			var recipeCategory = await _context.RecipeCategories.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (recipeCategory == null)
				throw new Exception("Recipe category not found");

			_context.Remove(recipeCategory);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of recipe categories from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<RecipeCategory>> GetAsync()
		{
			return _mapper.Map<IEnumerable<RecipeCategory>>(
				await _context.RecipeCategories.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a recipe category in the database, provided an existing recipe category exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<RecipeCategory> UpdateAsync(RecipeCategory item)
		{
			var dbRecipeCategory = await _context.RecipeCategories
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbRecipeCategory == null)
				throw new Exception("Recipe category not found");

			var updatedDbRecipeCategory = _mapper.Map(item, dbRecipeCategory);

			_context.RecipeCategories.Update(updatedDbRecipeCategory);
			await _context.SaveChangesAsync();

			return _mapper.Map<RecipeCategory>(updatedDbRecipeCategory);
		}
	}
}
