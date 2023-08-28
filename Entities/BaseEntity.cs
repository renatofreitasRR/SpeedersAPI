using SpeedersAPI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedersAPI.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Errors = new List<string>();
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }

        [NotMapped]
        public List<string> Errors { get; protected set; }

        public void SetId(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("");
            }
            else
            {
                Id = id;
            }
        }
    }
}
