using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VMStarter.Shared.Extensions;

namespace VMStarter.Shared.Actions
{
    public class RepositoryBase<ContextAggregate> where ContextAggregate:DbContext
    {
        private IDbContextTransaction transaction;
        private ContextAggregate databaseContext;
        protected ContextAggregate DatabaseContext
        {
            get
            {
                return databaseContext;
            }
        }

        public RepositoryBase(DbContextOptions<ContextAggregate> options)
        {
            databaseContext = (ContextAggregate)Activator.CreateInstance(typeof(ContextAggregate), args: options);
        }

        protected TMapDestination Map<TMapSource, TMapDestination>(TMapSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TMapSource, TMapDestination>();
            });

            return config.CreateMapper()
                .Map<TMapDestination>(source);
        }

        protected TMapDestination Map<TMapSource, TMapDestination>(TMapSource source, TMapDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TMapSource, TMapDestination>();
            });

            return config.CreateMapper()
                .Map<TMapSource, TMapDestination>(source, destination);
        }

        protected async Task<TMapDestination> MappAsync<TMapSource, TMapDestination>(TMapSource source, TMapDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TMapSource, TMapDestination>();
            });

            return await config.CreateMapper()
                .MapAsync<TMapSource, TMapDestination>(Task.Run(()=>source));
        }
    }
}
