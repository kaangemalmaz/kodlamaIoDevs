using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgramingLanguage : Entity
    {
        public string Name { get; set; }
        public ICollection<Technology> Technologies { get; set; }

        public ProgramingLanguage()
        {

        }


        public ProgramingLanguage(int id, string Name) : this()
        {
            this.Id = id;
            this.Name = Name;
        }
    }
}
