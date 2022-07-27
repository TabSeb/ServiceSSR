namespace ServicesSSrAPI.Models.Request
{
    public class ExerciseRequest
    {
        public int ExerciseId { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
