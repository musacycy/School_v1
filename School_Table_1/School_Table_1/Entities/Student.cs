using School_Table_1.Model;

namespace School_Table_1.Entities
{
    public class Student:BaseModel

    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RegisterYear { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
