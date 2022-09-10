using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Model
{

    public class RegFormDTO
    {
        public int StudentID { get; set; }

        public List<int> SubjectsIds { get; set; }
    }

    public class RegForm
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        public ICollection<RegFormItem> Items { get; set; }

    }
}
