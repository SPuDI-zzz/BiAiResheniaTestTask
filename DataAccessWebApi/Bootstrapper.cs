using Services.Palindrome;
using Services.SumOfEverySecondOddNumber;

namespace DataAccessWebApi
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddSumOfEverySecondOddNumberService()
                .AddPalindromeService()
                .AddSortNumbersService();

            return services;
        }
    }
}
