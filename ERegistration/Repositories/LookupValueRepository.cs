using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ERegistration.Repositories
{
    public class LookupValueRepository : ILookupValueRepository
    {
        private readonly IMemoryCache _cache; 
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public LookupValueRepository(IMemoryCache cache, ERegistrationDbContext eRegistrationDbContext)
        {
            _cache = cache;
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<List<LookupValue>> GetLookupForDropdownAsync()
        {
            const string cacheKey = "LookupDropdownList";
            if(!_cache.TryGetValue(cacheKey, out List<LookupValue>? lookupValues))
            {
                var dbLookupValues = await _eRegistrationDbContext.LookupValues.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(24));
                _cache.Set(cacheKey, dbLookupValues, cacheEntryOptions);
                lookupValues = dbLookupValues;
            }
            return lookupValues;
        }
    }
}