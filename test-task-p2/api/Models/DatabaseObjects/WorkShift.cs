using System;

namespace api.Models.DatabaseObjects
{
    public class WorkShift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
