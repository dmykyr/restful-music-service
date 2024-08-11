using MusicService.Models;
using System.Linq.Expressions;

namespace MusicService.Interfaces
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetMany(Expression<Func<Role, bool>> predicate);

        public Task<Role> Get(Guid id);

        public Task<Role> GetByName(string roleName);

        public Task<Role> Add(Role entity);

        public Task<Role> Update(Role entity);

        public Task<Role> Delete(Guid id);
    }
}
