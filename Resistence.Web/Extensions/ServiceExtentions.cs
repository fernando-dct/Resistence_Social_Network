using Microsoft.Extensions.DependencyInjection;
using Resistence_Business;
using Resistence_Entity.Interfaces;
using Resistence_Repository;

namespace Resistence_Web.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureBusiness(this IServiceCollection services)
        {
            BaseContext context = new BaseContext();

            RebeldeRepository rebeldeRepository = new RebeldeRepository(context);
            LocalRepository localRepository = new LocalRepository(context);
            ItemRepository itemRepository = new ItemRepository(context);
            InventarioRepository inventarioRepository = new InventarioRepository(context);

            RebeldeBusiness rebelde = new RebeldeBusiness(rebeldeRepository);
            RelatorioBusiness relatorio = new RelatorioBusiness(rebeldeRepository, itemRepository);
            LocalBusiness local = new LocalBusiness(localRepository);
            ItemBusiness item = new ItemBusiness(itemRepository);
            InventarioBusiness inventario = new InventarioBusiness(inventarioRepository, rebeldeRepository);

            services.AddSingleton<IRebeldeRepository>(rebeldeRepository);
            services.AddSingleton<ILocalRepository>(localRepository);
            services.AddSingleton<IItemRepository>(itemRepository);
            services.AddSingleton<IInventarioRepository>(inventarioRepository);

            services.AddSingleton<IRebeldeBusiness>(rebelde);
            services.AddSingleton<IRelatorioBusiness>(relatorio);
            services.AddSingleton<ILocalBusiness>(local);
            services.AddSingleton<IItemBusiness>(item);
            services.AddSingleton<IInventarioBusiness>(inventario);
        }
    }
}
