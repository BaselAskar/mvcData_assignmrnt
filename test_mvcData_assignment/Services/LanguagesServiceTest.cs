using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemnting;
using mvcData_assignmrnt.Repositories.Implemting;
using mvcData_assignmrnt.Services;
using mvcData_assignmrnt.Services.Implementing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_mvcData_assignment.Services
{
    public class LanguagesServiceTest : IClassFixture<DatabaseFixture>
    {
        private ILanguageService testObject;
        private readonly AppDbContext context;

        public LanguagesServiceTest(DatabaseFixture fixture)
        {
            testObject = new LanguageService(fixture.LanguageRepo);
            context = fixture.Context;
        }




        [Fact(DisplayName = "Success Add language")]
        public void AddLanguage_Test()
        {
            string langName = "Espanian";

            var result = testObject.Add(langName);

            var languages = context.Languages!.ToList();

            
            Assert.NotEqual(0, result.Id);
            Assert.Contains(languages, lang => lang.Name == langName);
        }



        [Theory(DisplayName = "Success in removing a language")]
        [InlineData(1)]
        [InlineData(3)]
        public void SuccessRemoveLanguage_Test(int languageId)
        {
            testObject.Remove(languageId);

            var languages = context.Languages!.ToList();

            Assert.DoesNotContain(languages, lang => lang.Id == languageId);
        }


        [Theory(DisplayName = "Throw an exception with removing language with worng id")]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void FieldToRemoveLanguage_Test(int languageId)
        {
            string exceptionMessage = "The language has not found";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => testObject.Remove(languageId));

            Assert.Contains(exceptionMessage, ex.Message);            
        }




    }
}
