using Microsoft.Extensions.DependencyInjection;

namespace Services.SumOfEverySecondOddNumber
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSumOfEverySecondOddNumberService(this IServiceCollection services)
        {
            services
                .AddSingleton<ISumOfEverySecondOddNumberService, SumOfEverySecondOddNumberService>();

            return services;
        }
    }
}

