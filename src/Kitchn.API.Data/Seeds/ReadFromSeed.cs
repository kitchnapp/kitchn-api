using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Kitchn.API.Data.Seeds
{
	/// <summary>
	/// Read objects from a source to convert into a seed object
	/// </summary>
	public class ReadFromSeed<T>
	{
		/// <summary>
		/// File path to read from
		/// </summary>
		private readonly string _file;

		/// <summary>
		/// Initialise the object with a given path
		/// </summary>
		/// <param name="file">Given file path</param>
		public ReadFromSeed(string file)
		{
			_file = file;
		}

		/// <summary>
		/// Retrieve the array of objects from the file
		/// </summary>
		/// <returns></returns>
		public List<T> GetObjects()
		{
			using StreamReader r = new StreamReader(_file);
			string content = r.ReadToEnd();

			var deserializer = new DeserializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();

			var seedList = deserializer.Deserialize<SeedList<T>>(content);

			return seedList.Items;
		}
	}
}
