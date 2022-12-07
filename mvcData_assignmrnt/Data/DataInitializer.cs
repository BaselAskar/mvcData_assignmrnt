using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Data
{
    public class DataInitializer : IDataInitializer
    {
        private readonly AppDbContext _context;

        public DataInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            //Seeding Languages
            if (!_context.Languages.Any())
            {
                List<Language> languages = new List<Language>
                {
                    new Language{Name= "Swedish"},
                    new Language{Name = "English"}
                };

                _context.Languages.AddRange(languages);
                _context.SaveChanges();
            }

            if (!_context.Countries.Any())
            {
                List<Country> countries = new List<Country>
                {
                    new Country{Name="Sweden",Cities = 
                        new List<City>
                        {
                            new City{Name = "Malmö"},
                            new City{Name = "Växjö"},
                            new City{Name = "Stockholm"}
                        }
                    }
                };


                _context.Countries.AddRange(countries);
                _context.SaveChanges();
            }
        }
    }
}
