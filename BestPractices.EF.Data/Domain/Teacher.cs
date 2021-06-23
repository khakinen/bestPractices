using System;

namespace BestPractices.EF.Data.Domain
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TeacherRank { get; set; }
    }
}