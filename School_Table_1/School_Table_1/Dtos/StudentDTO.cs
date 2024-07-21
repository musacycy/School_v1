namespace School_Table_1.Dtos
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RegisterYear { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

    }
}
