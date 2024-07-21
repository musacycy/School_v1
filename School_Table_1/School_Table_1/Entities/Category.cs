using School_Table_1.Model;

namespace School_Table_1.Entities
{
    public class Category :BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public int StudentCount { get; set; }
        public List<Student> Students { get; set; }
    }
}
