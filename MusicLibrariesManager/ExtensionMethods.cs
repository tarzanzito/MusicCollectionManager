
namespace MusicLibrariesManager
{
    public static class ExtensionMethods
    {
        public static int CountOccurencesOf(this string text, string comparison)
        {
            int len = text.Length;
            if (len == 0)
                return -1;

            int count = 0;
            int inx = text.IndexOf(comparison);

            while (inx != -1)
            {
                count++;

                if ((inx + 1) < len)
                    inx = text.IndexOf(comparison, (inx + 1));
                else
                    inx = -1;
            }

            return count;
        }

    }
}
