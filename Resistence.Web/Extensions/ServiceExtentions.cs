using Microsoft.Extensions.DependencyInjection;
using Resistence_Business;
using Resistence_Entity.Interfaces;
using Resistence_Repository;

namespace Resistence_Web.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRebeldeRepository, RebeldeRepository>();
            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();

            services.AddTransient<IRebeldeBusiness, RebeldeBusiness>();
            services.AddTransient<IRelatorioBusiness, RelatorioBusiness>();
            services.AddTransient<ILocalBusiness, LocalBusiness>();
            services.AddTransient<IItemBusiness, ItemBusiness>();
            services.AddTransient<IInventarioBusiness, InventarioBusiness>();
        }
    }
}
