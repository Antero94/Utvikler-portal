using System;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;


namespace Utvikler_portal.JobSeekerModul.Maps;

public class UserRegMap : IMaps<User, UserRegDTO>
{
	public UserRegDTO MapToDTO(User model)
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

	public User MapToModel(UserRegDTO dto)
	{
		var dtNow = DateTime.Now;

		return new User()
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Email = dto.Email,
			Created = dtNow,
			Updated = dtNow

		};

	}

}

