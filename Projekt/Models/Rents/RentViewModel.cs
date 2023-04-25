using Projekt.Models.Films;
using Projekt.Models.Users;

namespace Projekt.Models.Rents
{
    public class RentViewModel
    {
        public RentViewModel() 
        { 

        }

        public List<RentsModel> Rents { get; set; }
        public List<FilmsModel> Films { get; internal set; }
        public List<UserModel> Users { get; internal set; }
    }
}
