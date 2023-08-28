namespace SpeedersAPI.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {

        }

        public UserEntity(Guid id, string name, string password, string email)
        {
            base.SetId(id);
            this.SetUserName(name);
            this.SetPassword(password);
            this.SetEmail(email);
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public void SetUserName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                this.Errors.Add("O nome não pode ser nulo ou vazio");
            }

            this.UserName = name;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("O campo Nome não pode ser nulo ou vazio");
            }

            this.Password = password;

        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("O campo Nome não pode ser nulo ou vazio");
            }

            this.Email = email;
        }
    }

    
}
