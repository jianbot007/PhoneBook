using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookApplication.Models
{
	public class ContactPhone
	{
		public ContactDTO contact = new ContactDTO();
		public List<phoneDTO> phones = new List<phoneDTO>();

	}
}