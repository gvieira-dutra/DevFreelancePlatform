namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdSkill { get; private set; }
        public int IdUser { get; private set; }
    }
}
