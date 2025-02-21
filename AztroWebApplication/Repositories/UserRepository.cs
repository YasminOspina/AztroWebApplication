using AztroWebApplication.Models;
using AztroWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace AztroWebApplication.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext context)
        {
            db = context;
        }

        //Method to get all users
        public async Task<List<User>> GetAllUsers()
        {
            return await db.User.ToListAsync();
        }

         // Method to get a user by ID
        public async Task<User?> GetUserById(int id)
        {
            return await db.User.FirstOrDefaultAsync(user => user.Id == id);
        }

         // Method to create a new user
        public async Task<User> CreateUser(User user)
        {
            db.User.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

         // Method to update a user by ID
        public async Task<User?> UpdateUserById(int id, User user)
        {
            var existingUser = await db.User.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Age = user.Age;

            db.User.Update(existingUser);
            await db.SaveChangesAsync();

            return existingUser;
        }

            // Method to update a user
        public async Task<User?> UpdateUser(int id, User user)
        {
            var userToUpdate = await db.User.FirstOrDefaultAsync(u => u.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }

            foreach (PropertyInfo prop in typeof(User).GetProperties())
            {
                if (prop.GetValue(user) != null)
                {
                    prop.SetValue(userToUpdate, prop.GetValue(user));
                }
            }

            await db.SaveChangesAsync();
            return userToUpdate;
        }

        // Method to delete a user by ID
        public async Task<User?> DeleteUserById(int id)
        {
            var user = await db.User.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            db.User.Remove(user);
            await db.SaveChangesAsync();

            return user;
        }


        // Method to delete a user
        public async Task<User?> DeleteUser(int id)
        {
            var userToDelete = await db.User.FirstOrDefaultAsync(u => u.Id == id);
            if (userToDelete == null)
            {
                return null;
            }

            db.User.Remove(userToDelete);
            await db.SaveChangesAsync();
            return userToDelete;
        }

    }
}
