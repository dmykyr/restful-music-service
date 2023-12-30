using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly MusicDbContext _context;

        public RoleRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> Get(Guid id)
        {
            return await _context.Roles.FindAsync(id);
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
