using MusicService.Interfaces;
using MusicService.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MusicService.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MusicDbContext _context;

        public RoleRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetMany(Expression<Func<Role, bool>> predicate) => 
            await _context.Roles.Where(predicate).ToListAsync();

        public async Task<Role> Get(Guid id) => 
            await _context.Roles.FindAsync(id) ?? throw new Exception();

        public async Task<Role> GetByName(string roleName)
        {
            return await _context.Roles.FirstAsync(r => r.Name == roleName);
        }

        public async Task<Role> Add(Role entity)
        {
            await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Role> Update(Role entity)
        {
            _context.Roles.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Role> Delete(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();

                return role;
            }

            throw new NotImplementedException();
        }
    }
}
