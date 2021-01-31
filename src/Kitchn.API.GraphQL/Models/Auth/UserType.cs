using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchn.API.GraphQL.Models.Auth
{
	public class UserType : ObjectGraphType<User>
	{
		public UserType()
		{
			Name = "User";
			Description = "A user in the system.";

			Field(x => x.Id).Description("The ID of the user.");
			Field(x => x.Username).Description("The name of the user.");
			Field(x => x.Email).Description("The email of the user.");
		}
	}
}
