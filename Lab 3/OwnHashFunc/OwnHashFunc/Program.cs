using System.Collections;
using System.IO;
using System.Linq;

namespace OwnHashFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordBytes = File.ReadAllBytes("word.docx");
            var sourceBytes = File.ReadAllBytes("source.txt");
            var imageBytes = File.ReadAllBytes("image.bmp");

            var wordHash = Hasher.GetHashCode(wordBytes, 8);
            var sourceHash = Hasher.GetHashCode(sourceBytes, 8);
            var imageHash = Hasher.GetHashCode(imageBytes, 8);

            var resultString = string.Format("Word: {1}{0}Source code: {2}{0}Image: {3}",
                "\r\n",
                GetStringHash(wordHash),
                GetStringHash(sourceHash),
                GetStringHash(imageHash));

            File.WriteAllText("result_new.txt", resultString);
        }

        private static string GetStringHash(BitArray array)
        {
            return array.Cast<object>().Aggregate(string.Empty, (current, bit) => current + ((bool)bit ? "1" : "0"));
        }
    }
}
