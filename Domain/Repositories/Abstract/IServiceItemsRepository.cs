using Korelskiy.GlobalStatistic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.GlobalStatistic.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid Id);
        void SaveServiceItems(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
