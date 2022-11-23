namespace MonsterHunterTool.Infra.Extentions
{
    public static class StringExtentions
    {
        public static int ToInt(this string source, int defaultValue)
        {
            bool isInt = int.TryParse(source, out int number);
            return isInt ? number : defaultValue;
        }
    }
}
