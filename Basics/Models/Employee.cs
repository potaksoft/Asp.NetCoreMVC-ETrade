namespace Basics.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; }  =string.Empty;
        public string FullName =>$"{FirstName}{LastName.ToUpper()}";//readonly
        public int Age { get; set; }

    }
}