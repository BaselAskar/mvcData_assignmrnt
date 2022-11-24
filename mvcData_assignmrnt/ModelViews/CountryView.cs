namespace mvcData_assignmrnt.ModelViews
{
    public class CountryView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();

    }
}
