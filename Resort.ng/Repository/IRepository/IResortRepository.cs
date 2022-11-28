using Resort.ng.Model;
using System.Linq.Expressions;

namespace Resort.ng.Repository.IRepository
{
    public interface IResortRepository
    {


        Task UpdateAsync(Resorts entity);

        

    }
}
