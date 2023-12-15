namespace ExternalStringLibrary
{
    public static class ValidateString
    {
        public static bool Validate(string input)
        {
            return !(input.Contains('@'));
        }

    }
}