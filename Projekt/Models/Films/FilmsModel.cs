using Projekt.Models.Rents;

namespace Projekt.Models.Films
{
    public class FilmsModel
    {
        public FilmsModel(){ }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Director { get; set; }
        public int YearOfProduction { get; set; }
        public ICollection<RentsModel> Rents { get; set; }
    }
}
