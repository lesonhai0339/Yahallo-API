using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Functions
{
    public class Filters
    {
        protected static GroupsCharacter[] array = new GroupsCharacter[]
        {
            new GroupsCharacter("A", new List<char> { 'a', 'ă', 'â','A', 'Ă', 'Â'}),
            new GroupsCharacter("B", new List<char> { 'b', 'B' }),
            new GroupsCharacter("C", new List<char> { 'c', 'C' }),
            new GroupsCharacter("D", new List<char> { 'd', 'D','đ', 'Đ' }),
            new GroupsCharacter("E", new List<char> { 'e', 'è', 'é', 'ẻ', 'ẽ', 'ẹ', 'ê', 'ế', 'ệ', 'ề', 'ể', 'E', 'È', 'É', 'Ẻ', 'Ẽ', 'Ẹ', 'Ê', 'Ế', 'Ệ', 'Ề', 'Ể' }),
            new GroupsCharacter("G", new List<char> { 'g', 'G' }),
            new GroupsCharacter("H", new List<char> { 'h', 'H' }),
            new GroupsCharacter("I", new List<char> { 'i', 'ì', 'í', 'ỉ', 'ĩ', 'ị', 'I', 'Ì', 'Í', 'Ỉ', 'Ĩ', 'Ị' }),
            new GroupsCharacter("K", new List<char> { 'k', 'K' }),
            new GroupsCharacter("L", new List<char> { 'l', 'L' }),
            new GroupsCharacter("M", new List<char> { 'm', 'M' }),
            new GroupsCharacter("N", new List<char> { 'n', 'N' }),
            new GroupsCharacter("O", new List<char> { 'o', 'ò', 'ó', 'ỏ', 'õ', 'ọ', 'ô', 'ố', 'ộ', 'ồ', 'ổ', 'O', 'Ò', 'Ó', 'Ỏ', 'Õ', 'Ọ', 'Ô', 'Ố', 'Ộ', 'Ồ', 'Ổ','ơ', 'ớ', 'ợ', 'ờ', 'ở', 'Ơ', 'Ớ', 'Ợ', 'Ờ', 'Ở' }),
            new GroupsCharacter("P", new List<char> { 'p', 'P' }),
            new GroupsCharacter("Q", new List<char> { 'q', 'Q' }),
            new GroupsCharacter("R", new List<char> { 'r', 'R' }),
            new GroupsCharacter("S", new List<char> { 's', 'S' }),
            new GroupsCharacter("T", new List<char> { 't', 'T' }),
            new GroupsCharacter("U", new List<char> { 'u', 'ù', 'ú', 'ủ', 'ũ', 'ụ', 'ư', 'ứ', 'ự', 'ừ', 'ử', 'U', 'Ù', 'Ú', 'Ủ', 'Ũ', 'Ụ', 'Ư', 'Ứ', 'Ự', 'Ừ', 'Ử' }),
            new GroupsCharacter("V", new List<char> { 'v', 'V' }),
            new GroupsCharacter("X", new List<char> { 'x', 'X' }),
            new GroupsCharacter("Y", new List<char> { 'y', 'ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ', 'Y', 'Ỳ', 'Ý', 'Ỷ', 'Ỹ', 'Ỵ' }),
            new GroupsCharacter("Z", new List<char> { 'z', 'Z' })
        };
        public static bool CheckString(string str1, string str2)
        {
            string pattern = @"[^a-zA-Z0-9\u0080-\uFFFF]";
            var formatstr1 = Regex.Replace(str1, pattern, "");
            var formatstr2 = Regex.Replace(str2, pattern, "");
            List<string> liststr1 = new List<string>(), liststr2 = new List<string>();
            liststr1 = formatstr1.SelectMany(c => array
               .Where(x => x.code.Any(y => Convert.ToInt32(y) == Convert.ToInt32(c)))
               .Select(x => x.character))
               .ToList();

            liststr2 = formatstr2.SelectMany(c => array
                .Where(x => x.code.Any(y => Convert.ToInt32(y) == Convert.ToInt32(c)))
                .Select(x => x.character))
                .ToList();
            var check = liststr2.All(x => liststr1.Contains(x));
            return check;
        }
    }
    public class GroupsCharacter
    {
        public GroupsCharacter(string character, List<char> code)
        {
            this.character = character;
            this.code = code;
        }

        public string character { get; set; }
        public List<char> code { get; set; }
    }
}
