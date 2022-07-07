using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Jarvis
{
    internal class CreateGroups
    {
        public static List<string> itGroups = new List<string> { "IT", "Server Admins", "Client Admins" };
        public static List<string> pharmaGroups = new List<string> { "Distributors", "Manufacturers", "Patients", "Pharmaceuticals" };
        public static void CreateEvilGroups(DirectoryEntry evilDirectoryEntry)
        {
            DirectorySearcher searcher = new DirectorySearcher(evilDirectoryEntry);
            searcher.Filter = "(objectCategory=organizationalUnit)";
            var results = searcher.FindAll();
            
            if (results == null)
            {
                Console.WriteLine("No OUs found :(");
                Environment.Exit(1);
            }

            foreach (SearchResult r in results)
            {
                var ouName = r.Properties["name"][0].ToString();

                try
                {
                    if (ouName == "Executives")
                    {

                        DirectoryEntry addExecGroup = new DirectoryEntry(r.Path);
                        DirectoryEntry execGroup = addExecGroup.Children.Add("CN=" + ouName, "group");
                        execGroup.Properties["sAmAccountName"].Value = ouName;
                        execGroup.CommitChanges();
                    }

                    if (ouName == "HR")
                    {
                        DirectoryEntry addHrGroup = new DirectoryEntry(r.Path);
                        DirectoryEntry hRGroup = addHrGroup.Children.Add("CN=" + ouName, "group");
                        hRGroup.Properties["sAmAccountName"].Value = ouName;
                        hRGroup.CommitChanges();
                    }

                    if (ouName == "IT")
                    {
                        foreach (string gName in itGroups)
                        {
                            DirectoryEntry addGroup = new DirectoryEntry(r.Path);
                            DirectoryEntry groupName = addGroup.Children.Add("CN=" + gName, "group");
                            groupName.Properties["sAmAccountName"].Value = gName;
                            groupName.CommitChanges();
                        }
                    }

                    if (ouName == "Legal")
                    {
                        DirectoryEntry addLegalGroup = new DirectoryEntry(r.Path);
                        DirectoryEntry legalGroup = addLegalGroup.Children.Add("CN=" + ouName, "group");
                        legalGroup.Properties["sAmAccountName"].Value = ouName;
                        legalGroup.CommitChanges();
                    }

                    if (ouName == "Pharmaceuticals")
                    {
                        foreach (string gName in pharmaGroups)
                        {
                            DirectoryEntry addGroup = new DirectoryEntry(r.Path);
                            DirectoryEntry groupName = addGroup.Children.Add("CN=" + gName, "group");
                            groupName.Properties["sAmAccountName"].Value = gName;
                            groupName.CommitChanges();
                        }
                    }

                    if (ouName == "Sales")
                    {
                        DirectoryEntry addSalesGroup = new DirectoryEntry(r.Path);
                        DirectoryEntry salesGroup = addSalesGroup.Children.Add("CN=" + ouName, "group");
                        salesGroup.Properties["sAmAccountName"].Value = ouName;
                        salesGroup.CommitChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }
        }
    }
}

