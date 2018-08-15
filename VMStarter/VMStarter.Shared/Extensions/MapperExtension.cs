using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Extensions
{
    public static class MapperExtension
    {
		public static TMapDestination Map<TMapDestination>(this IDatabase source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IDatabase, TMapDestination>();
			});

			return config.CreateMapper()
				.Map<TMapDestination>(source);
		}

		public static TMapDestination Map<TMapDestination>(this IAggregateRoot source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IDatabase, TMapDestination>();
			});

			return config.CreateMapper()
				.Map<TMapDestination>(source);
		}

		public static TMapDestination Map<TMapDestination>(this IDatabase source, TMapDestination destination)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IDatabase, TMapDestination>();
			});

			return config.CreateMapper()
				.Map<IDatabase, TMapDestination>(source, destination);
		}
	}
}
