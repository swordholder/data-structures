namespace ConsoleApp
{
    public class Utils
    {
        public string ReplaceFirstOccurance(string str, string from, string to)
        {
            int index = str.IndexOf(from);
            if (index == -1)
                return str;

            var res = str.Substring(0, index);
            res += to + str.Substring(index + from.Length);

            return res;
        }
    }
}
