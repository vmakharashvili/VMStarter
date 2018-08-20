using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

       
            public static Task<TResult> MapAsync<TSource, TResult>(this IMapper mapper, Task<TSource> task)
            {
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task));
                }

                var tcs = new TaskCompletionSource<TResult>();

                task
                    .ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);

                task
                    .ContinueWith
                    (
                        t =>
                        {
                            tcs.TrySetResult(mapper.Map<TSource, TResult>(t.Result));
                        },
                        TaskContinuationOptions.OnlyOnRanToCompletion
                    );

                task
                    .ContinueWith
                    (
                        t => tcs.TrySetException(t.Exception),
                        TaskContinuationOptions.OnlyOnFaulted
                    );

                return tcs.Task;
            }
        
    }
}
