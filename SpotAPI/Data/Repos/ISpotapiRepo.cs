using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotAPI.Data.Repos
{
    public interface ISpotapiRepo
    {
        //fetch value from given data
        Task<SpotsAPI> GetAsync(DateTime czas);
        //get all
        Task<IEnumerable<SpotsAPI>> BrowseAsync();
        //save val to DB
        Task AddAsync(SpotsAPI newSpot);

    }
}
