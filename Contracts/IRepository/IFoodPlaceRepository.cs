using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodPlaceRepository: IRepositoryBase<FoodPlace>
    {
        Task<IEnumerable<FoodPlace>> Search(string data);
    }
}
