using AztroWebApplication.Data;
using AztroWebApplication.Models;
using AztroWebApplication.Repositories;

namespace AztroWebApplication.Services
{
    public class UserService
    {

        private readonly UserRepository userRepository;

        public UserService(ApplicationDbContext context)
        {
            userRepository = new UserRepository(context);
        
        }

         // Method to get all users
        public async Task<List<User>> GetAllUsers()
        {
            // Call the GetAllUsers method from the UserRepository class
            return await userRepository.GetAllUsers();
        }

         // Method to get a user by ID
        public async Task<User?> GetUserById(int id)
        {
            // Call the GetUserById method from the UserRepository class and return the user object
            return await userRepository.GetUserById(id);

        }

        // Method to create a new user
        public async Task<User?> CreateUser(User user)
        {
            // Check if the user is between 18 and 80 years old
            if (user.Age < 18 || user.Age > 80)
            {
                return null;
            }
            // Call the CreateUser method from the UserRepository class and return the created user object
            return await userRepository.CreateUser(user);
        }

         // Method to update a user by ID
        public async Task<User?> UpdateUserById(int id, User user)
        {
            if (user.Age < 18 || user.Age > 80)
            {
                return null;
            }
            
            return await userRepository.UpdateUserById(id, user);
        }


        // Method to delete a user by ID
        public async Task<User?> DeleteUserById(int id)
        {
            return await userRepository.DeleteUserById(id);
        }


        
    }
}