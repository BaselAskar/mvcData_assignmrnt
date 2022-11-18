using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace test_mvcData.Repositories
{
    public class PeopleRepoFixture : IDisposable
    {
        public IPeopleRepo PeopleRepo { get; private set; }
        public List<Person> PeopleData { get; private set; }
        private MemoryData _data;

        public PeopleRepoFixture()
        {
            PeopleRepo = new PeopleRepo();
            _data = new MemoryData();
            PeopleData = _data.People;

            List<Person> initalData = new List<Person>
            {
                new Person{Name="Basel Askar",PhoneNumber=0729002221,City="Malmö"},
                new Person{Name="Åsa Jonsson",PhoneNumber=079215214,City="Växjö"}
            };

            _data.People.AddRange(initalData);
            
        }


        public void Dispose()
        {
            _data.People = new List<Person>();
            MemoryData.RestIdCounter();
        }
    }




    public class PersonRepoTest : IClassFixture<PeopleRepoFixture>
    {
        private readonly IPeopleRepo objectTest;
        private readonly List<Person> peopleData;
        public PersonRepoTest(PeopleRepoFixture peopleRepoFixture)
        {
            objectTest = peopleRepoFixture.PeopleRepo;
            peopleData = peopleRepoFixture.PeopleData;
        }


        [Fact]
        public void AddPerson_Test()
        {
            Person person = new Person
            {
                Name = "Alaa Alkawarit",
                PhoneNumber = 072152142,
                City = "Stockholm"
            };

            var result = objectTest.AddPerson(person);

            Assert.NotNull(result);
            Assert.Equal(person,result);
            Assert.Contains(person, peopleData);
        }




        [Fact]
        public void Read_Test()
        {
            var result = objectTest.Read();

            Assert.Equal(2,result.Count);

        }


        [Theory]
        [InlineData(1,"Basel Askar")]
        [InlineData(2,"Åsa Jonsson")]
        public void ReadById_Test(int id,string name)
        {
            var result = objectTest.ReadById(id);

            Assert.NotNull(result);
            Assert.Equal(name,result.Name);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        public void ReadByIdPerson_Null_Test(int id)
        {
            var result = objectTest.ReadById(id);

            Assert.Null(result);
        }




        [Fact]
        public void Update_Test()
        {
            Person updatePerson = new Person
            {
                Id = 1,
                Name = "Test",
                PhoneNumber = 075212115,
                City = "Malmö"
            };

            var result = objectTest.Update(updatePerson);

            Person? testPerson = peopleData.FirstOrDefault(p => p.Id == updatePerson.Id);
            
            Assert.True(result);
            Assert.Equal(updatePerson.Name, testPerson!.Name);
            Assert.Equal(updatePerson.PhoneNumber, testPerson.PhoneNumber);
            Assert.Equal(updatePerson.City, testPerson.City);

        }


        [Fact]
        public void Delete_Test()
        {
            var persoTest = peopleData.FirstOrDefault(p => p.Id == 1);

            var result = objectTest.Delete(persoTest!);

            Assert.True(result);
            Assert.Single(peopleData);

        }



        [Fact]
        public void Delete_Feild_Test()
        {
            Person person = new Person
            {
                Name = "Test",
                PhoneNumber = 07215214,
                City = "City"
            };

            var result = objectTest.Delete(person);

            Assert.False(result);
        }
    }
}
