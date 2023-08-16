using Microsoft.Extensions.DependencyInjection;
using Services.SortNumbers;

namespace Services.SumOfEverySecondOddNumber
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSortNumbersService(this IServiceCollection services)
        {
            services
                .AddSingleton<ISortNumbersService, QuickSortService>();

            return services;
        }
    }
}

