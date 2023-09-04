using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;

namespace YuGiOhApi.Infra.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly YugiohContext _context;

    public UserRepository(YugiohContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<int> GetTotalUsers()
    {
        return await _context
            .Users
            .Include(user => user.Decks)
            .CountAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> FindAll()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<User?> FindById(string name)
    {
        var user = await _context
            .Users
            .Include(user => user.Decks)
            .FirstOrDefaultAsync(user => user.UserName == name);

        return user;
    }

    public async Task<User> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
