using Backend.Controllers;

namespace Backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrWhiteSpace(people.Name))
            {
                return false;
            }

            return true;
        }
    }
}
