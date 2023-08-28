using SpeedersAPI.Data;
using SpeedersAPI.Entities;
using SpeedersAPI.Repositories.Contracts;

namespace SpeedersAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public List<UserEntity> GetAll()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public UserEntity GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public UserEntity GetByEmailAndPassword(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            return user;
        }

        public void Post(UserEntity entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = this.GetById(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(UserEntity user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
