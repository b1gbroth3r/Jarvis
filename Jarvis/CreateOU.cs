using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Jarvis
{
    internal class CreateOU
    {
        public static void CreateParentOu(DirectoryEntry evilDirectoryEntry)
        {
            string ouName = "OU=US";
            string description = "Evil Corp US Organization";

            try
            {
                DirectoryEntry ou = evilDirectoryEntry.Children.Add(ouName, "OrganizationalUnit");
                ou.Properties["description"].Add(description);
                ou.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateChildOus(DirectoryEntry evilDirectoryEntry, List<string> subOUs)
        {
            string prefix = "OU=";
            string postfix = ",OU=US";

            foreach (string sub in subOUs)
            {
                string ouName = prefix + sub + postfix;
                try
                {
                    DirectoryEntry ou = evilDirectoryEntry.Children.Add(ouName, "OrganizationalUnit");
                    ou.CommitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
