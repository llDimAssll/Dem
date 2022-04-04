using Dem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        public async Task<Clients> GetById(int clientId)
        {
            using (var userRepository = new DemContext())
            {
                return userRepository.Clients.Where(u => u.ClientId == clientId).FirstOrDefault();
            }
        }
        public async Task<IEnumerable<Clients>> GetAll()
        {
            using (var userRepository = new DemContext())
            {
                return userRepository.Clients.ToList();
            }
        }
        public async Task Create(Clients client)
        {
            using (var userRepository = new DemContext())
            {
                userRepository.Clients.Add(client);
                userRepository.SaveChanges();
            }
        }
        public async Task Delete(Clients client)
        {
            using (var userRepository = new DemContext())
            {
                userRepository.Clients.Remove(client);
                userRepository.SaveChanges();
            }
        }
        public async Task<IEnumerable<Clients>> SearchByName(string name)
        {
            using (var userRepository = new DemContext())
            {
                return userRepository.Clients.Where(u => u.Name == name | u.Surname == name | u.Lastname == name).ToList();
            }
        }
        public async Task<int> Verification(string login, string password)
        {
            using (var userRepository = new DemContext())
            {
                var user = userRepository.Users.Where(u => u.Login == login).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password) return 1;
                    else return 2;
                }
                return 0;
            }
        }
    }
}
