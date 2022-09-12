using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Model
{
    public class RegFormItem
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int RegFormId { get; set; }
        public RegForm RegForm { get; set; }

    }
}
