using DB;

namespace ServicesSSrAPI.Request
{
    public class UserRequest
    {
         public string Name { get; set; }
         public int UserId { get; set; }
         public string Password { get; set; }
         //public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
