using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
	public enum SearchFieldType
	{
		[Display(Name = "Supplier Name")]
		SupplierName = 1,
		[Display(Name = "Email")]
		Email = 2,
		[Display(Name = "Naics Code")]
		NaicsCode = 3,
		[Display(Name = "State")]
		State = 4,
		[Display(Name = "City")]
		City = 5
	}
}
