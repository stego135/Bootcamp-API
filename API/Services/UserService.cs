using Bootcamp_API.Models;
using Bootcamp_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_API.Services;

public class UserService
{
    private readonly PokemonContext _context;

    public UserService(PokemonContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User? Get(int id)
    {
        return _context.Users.SingleOrDefault(p => p.Id == id);
    }

    public User Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }

    public void Delete(int id)
    {
        var userToDelete = _context.Users.Find(id);
        if (userToDelete is not null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }

    public void Update(User user)
    {
        var existingUser = _context.Users.SingleOrDefault(p => p.Id == user.Id);
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        _context.SaveChanges();
    }
}