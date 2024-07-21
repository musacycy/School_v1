namespace School_Table_1.Model
{
    public abstract class BaseModel
    {
        public BaseModel() 
        {
            Id=Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
