using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{
    public class UserRepository
    {
        private readonly MusicDbContext _context;

        public UserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }

            throw new NotImplementedException();
        }
    }
}