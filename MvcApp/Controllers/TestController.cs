using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.ViewModels;

namespace MvcApp.Controllers
{
    public class TestController : Controller
    {
        List<Person> people;
        List<Company> companies;

        public TestController()
        {
            Company microsoft = new Company(1, "Microsoft", "USA");
            Company google = new Company(2, "Google", "USA");
            Company jetbrains = new Company(3, "JetBrains", "Czech Republic");
            Company apple = new Company(4, "Apple", "USA");
            companies = new List<Company> { microsoft, google, jetbrains, apple };

            people = new List<Person>
            {
                new Person(1, "Tom", 37, apple),
                new Person(2, "Bob", 41, microsoft),
                new Person(3, "Sam", 28, google),
                new Person(4, "Bill", 32, google),
                new Person(5, "Kate", 33, jetbrains),
                new Person(6, "Alex", 25, jetbrains),
            };
        }

        public IActionResult Index(int? companyId)
        {
            // формируем список компаний для передачи в представление
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel(c.Id, c.Name)).ToList();

            // добавляем на первое место
            compModels.Insert(0, new CompanyModel(0, "All"));

            TestViewModel viewModel = new() { Companies = compModels, People = people };

            // если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                viewModel.People = people.Where(p => p.Work.Id == companyId);

            return View(viewModel);
        }
    }
}
