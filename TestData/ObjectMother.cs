namespace JBOB.TestData
{
    public static partial class ObjectMother
    {
        public static void Initialize()
        {
            Clear();

            Users.Initialize();
            Cards.Initialize();
        }

        public static void Clear()
        {
            // Cards.Clear();
            Users.Clear();
        }
    }
}
