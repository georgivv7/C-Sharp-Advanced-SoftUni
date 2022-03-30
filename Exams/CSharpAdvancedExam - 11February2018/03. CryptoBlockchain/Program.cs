using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder cryptoBlockChain = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                cryptoBlockChain.Append(line);
            }

            string pattern = @"\[([^\d[\]\{\}]*)(?<numbers>[\d]{3,})([^\d[\]\{\}]*)\]|\{([^\d\[\]\{\}]*)(?<numbers>[\d]{3,})([^\d[\]\{\}]*)\}";
            MatchCollection cryptoBlocks = Regex.Matches(cryptoBlockChain.ToString(), pattern);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < cryptoBlocks.Count; i++)
            {
                if (cryptoBlocks[i].Groups["numbers"].Value.Length % 3 != 0)
                {
                    continue;
                }

                var currentBlock = cryptoBlocks[i].Groups["numbers"].Value;
                var currentBlockLength = cryptoBlocks[i].Groups["numbers"].Value.Length;
                var totalLength = cryptoBlocks[i].Length;

                while (currentBlock.Length > 0)
                {
                    var currentChar = currentBlock.Substring(0, 3);
                    result.Append((char)(int.Parse(currentChar) - totalLength));
                    currentBlock = currentBlock.Substring(3);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
