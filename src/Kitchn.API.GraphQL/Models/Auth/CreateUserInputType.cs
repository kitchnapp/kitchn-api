using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchn.API.GraphQL.Models.Auth
{
	public class CreateUserInputType : InputObjectGraphType<User>
	{
		public CreateUserInputType()
		{
			Name = "CreateUserInputType";

			Field(x => x.Email).Description("The email of the user.");
			Field(x => x.Username).Description("The username of the user.");
			Field(x => x.Password).Description("The password of the user.");
		}
	}
}
