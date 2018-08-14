using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Models
{
	/// <summary>
	/// Just for Paging
	/// </summary>
    public class Filter
    {
		public int? Skip { get; set; }
		public int? Take { get; set; }
	}
}
