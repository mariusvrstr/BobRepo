namespace JBOB.Mapper
{
    public static class Mapper
    {

        public static JBOB.Users.User Map(this Database.Entities.User original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new JBOB.Users.User
            {
                UserId = original.UserId,
                Id = original.Id,
                Login = original.Login,
                Name = original.Name,
                Password = original.Password,
                Roles = original.Roles,
                Surname = original.Surname,
            };

            return mapped;
        }

        public static Database.Entities.User Map(this JBOB.Users.User original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new Database.Entities.User
            {
                UserId = original.UserId,
                Id = original.Id,
                Login = original.Login,
                Name = original.Name,
                Password = original.Password,
                Roles = original.Roles,
                Surname = original.Surname,
            };

            return mapped;
        }

        public static JBOB.Cards.Card Map(this Database.Entities.Card original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new JBOB.Cards.Card
            {
                CardId = original.CardId,
                Id = original.Id,
                Name = original.Name,
                Description = original.Description,
                Weight = original.Weight
            };

            return mapped;
        }

        public static Database.Entities.Card Map(this JBOB.Cards.Card original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new Database.Entities.Card
            {
                CardId = original.CardId,
                Id = original.Id,
                Name = original.Name,
                Description = original.Description,
                Weight = original.Weight
            };

            return mapped;
        }

    }
}
