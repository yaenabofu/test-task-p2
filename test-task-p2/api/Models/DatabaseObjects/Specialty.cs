namespace api.Models.DatabaseObjects
{
    public class Specialty
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
    }
}
