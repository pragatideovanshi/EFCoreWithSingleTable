using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstSingleTable.Models
{
    public class Student
    {
        [Key] // Auto /increment By default
        public int Id { get; set; }

        [Column("StudentName", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("Gender", TypeName = "varchar(100)")]
        public string Gender { get; set; }

        public int Age { get; set; }
    }
}