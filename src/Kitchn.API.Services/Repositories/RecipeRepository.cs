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
	/// Implementation for accessing recipes
	/// </summary>
	public class RecipeRepository : IRepository<Recipe>
	{
		private readonly KitchnDbContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Repository for accessing stored recipes
		/// </summary>
		/// <param name="context">EntityFramework context to communicate over</param>
		/// <param name="mapper">Mapper implementation</param>
		public RecipeRepository(KitchnDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Adds the provided item into the database
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Recipe> AddAsync(Recipe item)
		{
			if (item.Id != default)
				throw new ArgumentException("Recipe ID cannot have a value");
			if (string.IsNullOrEmpty(item.Name))
				throw new ArgumentException("Recipe title cannot be null");

			var dbRecipe = _mapper.Map<Data.Models.Recipe>(item);

			await _context.AddAsync(dbRecipe);
			await _context.SaveChangesAsync();

			return _mapper.Map<Recipe>(dbRecipe);
		}

		/// <summary>
		/// Deletes the provided recipe by its ID property
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Recipe item)
		{
			var recipe = await _context.Recipes.Where(q => q.Id == item.Id).FirstOrDefaultAsync();

			if (recipe == null)
				throw new Exception("Recipe not found");

			_context.Remove(recipe);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieves the list of recipes from the database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Recipe>> GetAsync()
		{
			return _mapper.Map<IEnumerable<Recipe>>(
				await _context.Recipes.ToListAsync()
			);
		}

		/// <summary>
		/// Updates a recipe in the database, provided an existing recipe exists with the ID in the provided item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Recipe> UpdateAsync(Recipe item)
		{
			var dbRecipe = await _context.Recipes
						.Where(q => q.Id == item.Id)
						.FirstOrDefaultAsync();

			if (dbRecipe == null)
				throw new Exception("Recipe not found");

			var updatedDbRecipe = _mapper.Map(item, dbRecipe);

			_context.Recipes.Update(updatedDbRecipe);
			await _context.SaveChangesAsync();

			return _mapper.Map<Recipe>(updatedDbRecipe);
		}
	}
}
