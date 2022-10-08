using System;
using System.Collections;
using System.Collections.Generic;

namespace api.Models.DatabaseObjects
{
    public class Worker
    {
        public int Id { get; set; }
        public string Snils { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Thirdname { get; set; }
        public DateTime Birthday { get; set; }
        public IList<WorkShift> WorkShifts { get; set; }
        public IList<Specialty> Specialties { get; set; }
    }
}
