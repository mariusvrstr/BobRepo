namespace JBOB.Mapper
{
    public static class Mapper
    {

        public static JBOB.Users.User Map(this JBOB.Entities.User original)
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

        public static JBOB.Entities.User Map(this JBOB.Users.User original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new JBOB.Entities.User
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

        public static JBOB.Cards.Card Map(this JBOB.Entities.Card original)
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
                Category = original.Category,
                ActivityOptions = original.ActivityOptions,
                Weight = original.Weight
            };

            return mapped;
        }

        public static JBOB.Entities.Card Map(this JBOB.Cards.Card original)
        {
            if (original == null)
            {
                return null;
            }

            var mapped = new JBOB.Entities.Card
            {
                CardId = original.CardId,
                Id = original.Id,
                Name = original.Name,
                Description = original.Description,
                Category = original.Category,
                ActivityOptions = original.ActivityOptions,
                Weight = original.Weight
            };

            return mapped;
        }

    }
}
