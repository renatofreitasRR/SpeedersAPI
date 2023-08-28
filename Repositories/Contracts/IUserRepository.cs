using SpeedersAPI.Entities;

namespace SpeedersAPI.Repositories.Contracts
{
    public interface IUserRepository
    {
        UserEntity GetByEmailAndPassword(string email, string password);
        List<UserEntity> GetAll();
        UserEntity GetById(Guid id);
        void Post(UserEntity entity);
        void Delete(Guid id);
        void Update(UserEntity user);
    }
}
