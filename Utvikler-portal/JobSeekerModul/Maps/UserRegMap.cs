using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Maps;

public class UserRegMap : IMaps<User, UserRegDTO>
{
	public UserRegDTO? MapToDTO(User model)
	{
		if (model == null)
			return null;

		return new UserRegDTO

		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.Email

		};
	}

	public User MapToModel(UserRegDTO dTO)
	{
		var dtNow = DateTime.Now;

		return new User()
		{
			FirstName = dTO.FirstName,
			LastName = dTO.LastName,
			Email = dTO.Email,
			Created = dtNow,
			Updated = dtNow
		};
	}
}

