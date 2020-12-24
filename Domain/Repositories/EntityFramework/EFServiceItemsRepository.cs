using Korelskiy.GlobalStatistic.Domain.Entities;
using Korelskiy.GlobalStatistic.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.GlobalStatistic.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }

        public ServiceItem GetServiceItemById(Guid Id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public void SaveServiceItems(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
