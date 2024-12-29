using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Context;
using ModelsLayer.Models;
using RepositoryLayer.Classes;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class UserService : EntityService<User>, IUserService
    {
        private readonly UserRepository _UserRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(ApplicationDbContext context, UserRepository userRepository) : base(context)
        {
            _UserRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }

        public User Authenticate(string number, string password)
        {
            var user =  _UserRepository.GetAll().FirstOrDefault(u => u.PhoneNumber == number);
            if (user == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            return user;
        }
        public string HashPassword(User user)
        {
            string password = _passwordHasher.HashPassword(user, user.Password);
            return password;
        }
    }
}
