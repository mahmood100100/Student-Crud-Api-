namespace StudentCrudApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Bio { get; set; } = null!;
    }
}