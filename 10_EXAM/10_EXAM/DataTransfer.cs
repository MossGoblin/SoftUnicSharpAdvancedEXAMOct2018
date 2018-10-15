using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _10_EXAM
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string pattern = "s:([^;]+);r:([^;]+);m--(\"[a-zA-Z ]+\")";
            int msgSize = 0;

            for (int i = 0; i < number; i++)
            {
                string cmmLine = Console.ReadLine();
                MatchCollection crrLine = Regex.Matches(cmmLine, pattern);

                // Check validity
                if (crrLine.Count > 0)
                {
                    if (crrLine[0].Groups.Count > 3)
                    {
                        string senderRough = crrLine[0].Groups[1].Value;
                        string recepientRough = crrLine[0].Groups[2].Value;
                        string messageRough = crrLine[0].Groups[3].Value;

                        msgSize += ExtractDigits(senderRough);
                        msgSize += ExtractDigits(recepientRough);
                        // clear names
                        string senderName = "";
                        for (int sn = 0; sn < senderRough.Length; sn++)
                        {
                            if (Char.IsLetter(senderRough[sn]) || senderRough[sn] == ' ')
                            {
                                senderName += senderRough[sn];
                            }
                        }

                        string recieverName = "";
                        for (int rn = 0; rn < recepientRough.Length; rn++)
                        {
                            if (Char.IsLetter(recepientRough[rn]) || recepientRough[rn] == ' ')
                            {
                                recieverName += recepientRough[rn];
                            }
                        }

                        Console.WriteLine($"{senderName} says {messageRough} to {recieverName}");
                    }
                }
                //extract size
            }
            Console.WriteLine($"Total data transferred: {msgSize}MB");
        }

        private static int ExtractDigits(string senderRough)
        {
            int msgSize = 0;
            for (int j = 0; j < senderRough.Length; j++)
            {
                if (Char.IsDigit(senderRough[j]))
                {
                    msgSize += int.Parse(senderRough[j].ToString());
                }
            }
            return msgSize;
        }
    }
}
