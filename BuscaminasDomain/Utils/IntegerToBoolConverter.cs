namespace BuscaminasDomain.Utils
{
    internal class IntegerToBoolConverter
    {
        public static bool GetBool(int value)
        {
            bool result;
            if (value == 0)
            {
                result = false;
            } else
            {
                result = true;
            }
            return result;
        }

        public static int GetInt(bool value)
        {
            int result;
            if (value)
            {
                result = 1;
            } else
            {
                result = 0;
            }
            return result;
        }
    }
}
