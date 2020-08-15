using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.DAL
{
    public interface IGenericManager<TEntityViewModel,TEntity>
    {
        Task<TEntityViewModel> GetById(int id);

        Task<IEnumerable<TEntityViewModel>> GetAll();

        Task<TEntityViewModel> Add(TEntity entity);

        Task<TEntityViewModel> Edit(TEntity entity);

        Task Delete(int id);
    }
}
