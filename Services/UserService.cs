using Bootcamp_API.Models;

namespace Bootcamp_API.Services;

public static class UserService
{
    static List<User> Users { get; }
    static int nextId = 3;
    static UserService()
    {
        Users = new List<User>
        {
            new User {id = 1, email = "test@test.com", password = "test"},
            new User {id = 2, email = "testing@test.com", password = "a"}
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.id == id);

    public static void Add(User user)
    {
        user.id = nextId++;
        Users.Add(user);
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if(user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.id == user.id);
        if(index == -1)
            return;

        Users[index] = user;
    }
}