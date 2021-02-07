using Kitchn.API.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kitchn.API.Services.Interfaces
{
	/// <summary>
	/// Repository contract for default CRUD operations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		/// <summary>
		/// Get the list of items in the repository
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<T>> GetAsync();

		/// <summary>
		/// Add an item into the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The new object</returns>
		Task<T> AddAsync(T item);

		/// <summary>
		/// Update an object that exists in the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The updated object</returns>
		Task<T> UpdateAsync(T item);

		/// <summary>
		/// Delete an item that exists in the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task DeleteAsync(T item);
	}
}
