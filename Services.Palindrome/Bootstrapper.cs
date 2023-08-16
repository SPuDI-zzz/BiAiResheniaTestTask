using Microsoft.Extensions.DependencyInjection;

namespace Services.Palindrome
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddPalindromeService(this IServiceCollection services)
        {
            services
                .AddSingleton<IPalindromeService, PalindromeService>();

            return services;
        }
    }
}
