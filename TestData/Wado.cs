using JBOB.Interaction;

namespace TestData
{
    public static class Wado
    {
        public static void ClearDatabase()
        {
            var context = DataContextFactory.CreateContext();

            context.UserRepository.DeleteAllUsers();

            context.SaveChanges();

        }
    }
}
