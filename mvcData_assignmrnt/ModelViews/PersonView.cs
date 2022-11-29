namespace mvcData_assignmrnt.ModelViews
{
    public class PersonView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public List<string> Languages { get; set; } = new();

    }
}
