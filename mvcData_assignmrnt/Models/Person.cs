namespace mvcData_assignmrnt.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? City { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {

            return Id + Name != null ? Name!.GetHashCode() : 0 + PhoneNumber.GetHashCode() + City != null ? City!.GetHashCode() : 0;
        }
    }
}
