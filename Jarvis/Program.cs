using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Threading;

namespace Jarvis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(30000);
            List<string> childOUs = new List<string> { "Executives", "HR", "IT", "Legal", "Pharmaceuticals", "Sales", "Servers", "Clients" };
            DirectoryEntry adEntry;
            
            string path;

            path = $"LDAP://{args[0]}:389";
            adEntry = new DirectoryEntry(path);
            Console.WriteLine();

            try
            {
                adEntry.RefreshCache();
                Console.WriteLine("[*] Connected to: " + adEntry.Path);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("[+] Creating Organizational Units...");
            CreateOU.CreateParentOu(adEntry);
            CreateOU.CreateChildOus(adEntry, childOUs);

            Console.WriteLine("[+] Creating " + adEntry.Name + " security groups");
            CreateGroups.CreateEvilGroups(adEntry);

            Console.WriteLine("[+] Creating user accounts..." );
            CreateUsers.CreateEvilUsers(adEntry);

            Console.WriteLine("[+] Adding users to groups...");
            CreateUsers.AddEvilUsersToGroups(adEntry);
            Console.WriteLine();

            Console.WriteLine("[*] AD configured with OUs, Groups, Users, and proper Group Memberships. Enjoy :)");
        }
    }
}
