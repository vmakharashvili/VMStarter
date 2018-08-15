using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Models
{
    public class PagedList<T>
    {
		public List<T> List { get; set; }
		public int TotalNumber { get; set; }
	}
}
