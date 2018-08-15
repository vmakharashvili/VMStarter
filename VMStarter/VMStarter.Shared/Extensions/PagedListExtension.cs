using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMStarter.Shared.Models;
using VMStarter.Shared.Extensions;

namespace VMStarter.Shared.Extensions
{
    public static class PagedListExtension
    {
		public static PagedList<Aggregate> ToPagedList<Aggregate, FilterObj>(this IQueryable<Aggregate> list, Filter filter, Func<Aggregate, string> order=null) where FilterObj:Filter
		{
			PagedList<Aggregate> myList = new PagedList<Aggregate>();
			myList.TotalNumber = list.ToList().Count;
			myList.List = list.OrderBy(f => order(f)).Skip((filter.Skip == null && filter.Take == null) ? 0 : (filter.Skip.Value * filter.Take.Value)).Take((filter.Skip == null && filter.Take == null) ? myList.TotalNumber:filter.Take.Value).ToList();
			return myList;
		}

		public static PagedList<ViewTable> ToMappedPagedList<DBTable, ViewTable, FilterObj>(this IQueryable<DBTable> dblist,
			Filter filter, Func<DBTable, bool> func = null, Func<ViewTable, string> order = null)
			where FilterObj : Filter where DBTable:IDatabase
		{
			PagedList<ViewTable> list = new PagedList<ViewTable>();
			list.TotalNumber = dblist.ToList().Count;
			list.List = dblist.Where(f => func == null || func(f)).Select(f=>f.Map<ViewTable>()).OrderBy(f => order(f)).Skip((filter.Skip == null && filter.Take == null) ? 0 : (filter.Skip.Value * filter.Take.Value))
			.Take((filter.Skip == null && filter.Take == null) ? list.TotalNumber : filter.Take.Value).ToList();
			return list;
		}

	}
}
