using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgramingLanguage? ProgramingLanguage { get; set; }

        public Technology()
        {
        }

        public Technology(int id, string name, int programingLanguageId)
        {
            Id = id;
            Name = name;
            ProgramingLanguageId = programingLanguageId;
        }
    }
}
