using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            string cmmLine = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> userList = new Dictionary<string, Dictionary<string, int>>();

            while (cmmLine.ToLower() != "end")
            {

                // BAN OR ADD
                // if ADD USER
                if (cmmLine.Substring(0, 3) != "ban")
                {
                    string[] commands = cmmLine
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string name = commands[0];
                    string tag = commands[1];
                    int score = int.Parse(commands[2]);

                    // new user?
                    if (!userList.ContainsKey(name))
                    {
                        Dictionary<string, int> newPair = new Dictionary<string, int>();
                        newPair.Add(tag, score);
                        userList.Add(name, newPair);
                    }
                    // old user
                    else
                    {
                        // new tag?
                        if (!userList[name].ContainsKey(tag))
                        {
                            userList[name].Add(tag, score);
                        }
                        // old user, old tag
                        else
                        {
                            userList[name][tag] += score;
                        }
                    }
                }
                // IF BAN USER
                else
                {
                    string nameToBan = cmmLine.Substring(4);
                    if (userList.ContainsKey(nameToBan))
                    {
                        userList.Remove(nameToBan);
                    }
                }

                cmmLine = Console.ReadLine();
            }

            // print

            foreach (var user in userList.OrderByDescending(s => sumLikes(s)).ThenBy(t => sumTags(t)))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }

        private static object sumTags(KeyValuePair<string, Dictionary<string, int>> t)
        {
            int ttl = 0;
            foreach (var tag in t.Value)
            {
                ttl ++;
            }
            return ttl;
        }

        private static object sumLikes(KeyValuePair<string, Dictionary<string, int>> s)
        {
            int ttl = 0;
            foreach (var tag in s.Value)
            {
                ttl += tag.Value;
            }
            return ttl;
        }
    }
}
