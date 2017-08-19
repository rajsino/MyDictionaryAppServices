using MyDictionaryServices.Models.Profiles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDictionaryServices.Queries.Profiles
{
    public interface ITenantQueries
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Tenant GetById(int id);
        Tenant GetByUserId(int userid);
    }
}
