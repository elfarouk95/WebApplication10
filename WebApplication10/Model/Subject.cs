using System.Collections.Generic;

namespace WebApplication10.Model
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RegFormItem> Items { get; set; }

    }
}
