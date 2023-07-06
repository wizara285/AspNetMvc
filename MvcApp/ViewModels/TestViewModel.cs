using MvcApp.Models;

namespace MvcApp.ViewModels
{
    public class TestViewModel
    {
        public IEnumerable<Person> People = new List<Person>();
        public IEnumerable<CompanyModel> Companies = new List<CompanyModel>();
    }
}
