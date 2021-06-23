using System;

namespace BestPractices.EF.Data.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StudentRank { get; set; }
    }
}