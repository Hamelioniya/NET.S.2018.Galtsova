using Task2.Solution;

namespace Task2.Tests
{
    public static class Program
    {
        public static void Main()
        {
            RandomBytesFileGenerator bytesGenerator = new RandomBytesFileGenerator();
            bytesGenerator.GenerateFiles(2, 23);

            RandomCharsFileGenerator charsGenerator = new RandomCharsFileGenerator();
            charsGenerator.GenerateFiles(1, 25);
        }
    }
}
