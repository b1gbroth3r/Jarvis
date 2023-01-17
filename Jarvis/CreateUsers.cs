using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Jarvis
{
    internal class CreateUsers
    {
        public static List<string> users2 = new List<string> { "Darlene Alderson", "Darlene Alderson (Admin)", "Elliot Alderson", "Elliot Alderson (Admin)",
          "Leslie Romero", "mr.robot", "Shama Biswas", "Sunil Markesh", "Tyrell Wellick", "Tyrell Wellick (Admin)" };
        public static List<string> hrUserList = new List<string> { "Joanna Wellick", "Krista Gordon", "Sharon Knowles" };
        public static List<string> execUserList = new List<string> { "Phillip Price", "Scott Knowles", "Terry Colby" };
        public static List<string> legalUserList = new List<string> { "Angela Moss", "Dom DiPierro", "Susan Jacobs" };
        public static List<string> pharmaUserList = new List<string> { "Fernando Vera", "Leon", "Shayla Nico" };
        public static List<string> salesUserList = new List<string> { "Ollie Parker" };

        public static void CreateEvilUsers(DirectoryEntry evilDirectoryEntry, string domain)
        {
            string upnSuffix = "@" + domain;
            DirectorySearcher searcher = new DirectorySearcher(evilDirectoryEntry.Children.Find("OU=US"));
            searcher.Filter = "(objectCategory=organizationalUnit)";
            var results = searcher.FindAll();

            if (results == null)
            {
                Console.WriteLine("No groups found :(");
                Environment.Exit(1);
            }

            foreach (SearchResult r in results)
            {
                var ouName = r.Properties["name"][0].ToString();

                try
                {
                    if (ouName == "Executives")
                    {
                        foreach (string execName in execUserList)
                        {
                            
                            string samAccountName = execName.ToLower().Replace(" ", ".");
                            DirectoryEntry exec = new DirectoryEntry(r.Path);
                            DirectoryEntry addExec = exec.Children.Add("CN=" + execName, "user");
                            addExec.Properties["sAmAccountName"].Value = samAccountName;
                            addExec.CommitChanges();
                            // need to commit between account creation and setting password
                            addExec.Invoke("SetPassword", new object[] {"Password1"});
                            addExec.CommitChanges();

                            addExec.Properties["displayName"].Value = execName;
                            addExec.CommitChanges();

                            addExec.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addExec.CommitChanges();

                            addExec.Properties["userAccountControl"].Value = 0x10200; // normal account & password does not expire
                            addExec.CommitChanges();
                        }
                    }

                    if (ouName == "HR")
                    {
                        foreach (string hrName in hrUserList)
                        {
                            string samAccountName = hrName.ToLower().Replace(" ", ".");
                            DirectoryEntry hr = new DirectoryEntry(r.Path);
                            DirectoryEntry addHr = hr.Children.Add("CN=" + hrName, "user");

                            addHr.Properties["sAmAccountName"].Value = samAccountName;
                            addHr.CommitChanges();

                            addHr.Invoke("SetPassword", new object[] {"Password1"});
                            addHr.CommitChanges();

                            addHr.Properties["displayName"].Value = hrName;
                            addHr.CommitChanges();

                            addHr.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addHr.CommitChanges();

                            addHr.Properties["userAccountControl"].Value = 0x10200;
                            addHr.CommitChanges();
                        }
                    }

                    if (ouName == "IT")
                    {
                        foreach (string itName in users2)
                        {
                            string samAccountName;

                            if (itName.Contains("(Admin)"))
                            {
                                var t = itName.ToLower().Replace(" ", ".").Split('.');
                                samAccountName = t[0] + "." + t[1] + "-adm";
                            }
                            else
                            {
                                var temp = itName.ToLower().Replace(" ", ".").Split('.');
                                samAccountName = temp[0] + "." + temp[1];
                            }

                            DirectoryEntry it = new DirectoryEntry(r.Path);
                            DirectoryEntry addIt = it.Children.Add("CN=" + itName, "user");

                            addIt.Properties["sAmAccountName"].Value = samAccountName;
                            addIt.CommitChanges();

                            addIt.Invoke("SetPassword", new object[] { "Password1" });
                            addIt.CommitChanges();

                            addIt.Properties["displayName"].Value = itName;
                            addIt.CommitChanges();

                            addIt.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addIt.CommitChanges();

                            addIt.Properties["userAccountControl"].Value = 0x10200;
                            addIt.CommitChanges();
                        }
                    }

                    if (ouName == "Legal")
                    {
                        foreach (string legalName in legalUserList)
                        {
                            string samAccountName = legalName.ToLower().Replace(" ", ".");
                            DirectoryEntry legal = new DirectoryEntry(r.Path);
                            DirectoryEntry addLegal = legal.Children.Add("CN=" + legalName, "user");

                            addLegal.Properties["sAmAccountName"].Value = samAccountName;
                            addLegal.CommitChanges();

                            addLegal.Invoke("SetPassword", new object[] { "Password1" });
                            addLegal.CommitChanges();

                            addLegal.Properties["displayName"].Value = legalName;
                            addLegal.CommitChanges();

                            addLegal.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addLegal.CommitChanges();

                            addLegal.Properties["userAccountControl"].Value = 0x10200;
                            addLegal.CommitChanges();
                        }
                    }

                    if (ouName == "Pharmaceuticals")
                    {
                        foreach (string pharmaName in pharmaUserList)
                        {
                            string samAccountName = pharmaName.ToLower().Replace(" ", ".");
                            DirectoryEntry pharma = new DirectoryEntry(r.Path);
                            DirectoryEntry addPharma = pharma.Children.Add("CN=" + pharmaName, "user");

                            addPharma.Properties["sAmAccountName"].Value = samAccountName;
                            addPharma.CommitChanges();

                            addPharma.Invoke("SetPassword", new object[] { "Password1" });
                            addPharma.CommitChanges();

                            addPharma.Properties["displayName"].Value = pharmaName;
                            addPharma.CommitChanges();

                            addPharma.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addPharma.CommitChanges();

                            addPharma.Properties["userAccountControl"].Value = 0x10200;
                            addPharma.CommitChanges();
                        }
                    }

                    if (ouName == "Sales")
                    {
                        foreach (string salesName in salesUserList)
                        {
                            string samAccountName = salesName.ToLower().Replace(" ", ".");
                            DirectoryEntry sales = new DirectoryEntry(r.Path);
                            DirectoryEntry addSales = sales.Children.Add("CN=" + salesName, "user");

                            addSales.Properties["sAmAccountName"].Value = samAccountName;
                            addSales.CommitChanges();

                            addSales.Invoke("SetPassword", new object[] { "Password1" });
                            addSales.CommitChanges();

                            addSales.Properties["displayName"].Value = salesName;
                            addSales.CommitChanges();

                            addSales.Properties["userPrincipalName"].Value = samAccountName + upnSuffix;
                            addSales.CommitChanges();

                            addSales.Properties["userAccountControl"].Value = 0x10200;
                            addSales.CommitChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // https://stackoverflow.com/questions/2143052/adding-and-removing-users-from-active-directory-groups-in-net  -- made adding users to groups ezpz
        public static void AddEvilUsersToGroups(DirectoryEntry evilDirectoryEntry)
        {
            DirectorySearcher searcher = new DirectorySearcher(evilDirectoryEntry.Children.Find("OU=US"));
            searcher.Filter = "(objectCategory=User)";
            var results = searcher.FindAll();

            foreach (SearchResult result in results)
            {
                var userName = result.Properties["sAmAccountName"][0].ToString();
                var properties = result.Properties["distinguishedName"][0].ToString();

                try
                {
                    if (properties.Contains("Executives"))
                    {
                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal execGroup = GroupPrincipal.FindByIdentity(principalContext, "Executives");
                            execGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            execGroup.Save();
                        }
                    }

                    if (properties.Contains("HR"))
                    {
                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal hrGroup = GroupPrincipal.FindByIdentity(principalContext, "HR");
                            hrGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            hrGroup.Save();
                        }
                    }

                    if (properties.Contains("IT"))
                    {

                        if (userName == "darlene.alderson-adm" || userName == "elliot.alderson-adm")
                        {
                            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                            {
                                GroupPrincipal srvAdminGroup = GroupPrincipal.FindByIdentity(principalContext, "Server Admins");
                                srvAdminGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                                srvAdminGroup.Save();
                            }
                        }
                        if (userName == "tyrell.wellick-adm")
                        {
                            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                            {
                                GroupPrincipal clientAdminGroup = GroupPrincipal.FindByIdentity(principalContext, "Client Admins");
                                clientAdminGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                                clientAdminGroup.Save();
                            }
                        }

                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal itGroup = GroupPrincipal.FindByIdentity(principalContext, "IT");
                            itGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            itGroup.Save();
                        }
                    }

                    if (properties.Contains("Legal"))
                    {
                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal legalGroup = GroupPrincipal.FindByIdentity(principalContext, "Legal");
                            legalGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            legalGroup.Save();
                        }
                    }

                    if (properties.Contains("Pharmaceuticals"))
                    {
                        if (userName == "shayla.nico")
                        {
                            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                            {
                                GroupPrincipal distGroup = GroupPrincipal.FindByIdentity(principalContext, "Distributors");
                                distGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                                distGroup.Save();
                            }
                        }

                        if (userName == "leon")
                        {
                            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                            {
                                GroupPrincipal patGroup = GroupPrincipal.FindByIdentity(principalContext, "Patients");
                                patGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                                patGroup.Save();
                            }
                        }

                        if (userName == "fernando.vera")
                        {
                            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                            {
                                GroupPrincipal manufGroup = GroupPrincipal.FindByIdentity(principalContext, "Manufacturers");
                                manufGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                                manufGroup.Save();
                            }
                        }

                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal pharmaGroup = GroupPrincipal.FindByIdentity(principalContext, "Pharmaceuticals");
                            pharmaGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            pharmaGroup.Save();
                        }
                    }

                    if (properties.Contains("Sales"))
                    {
                        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
                        {
                            GroupPrincipal salesGroup = GroupPrincipal.FindByIdentity(principalContext, "Sales");
                            salesGroup.Members.Add(principalContext, IdentityType.SamAccountName, userName);
                            salesGroup.Save();
                        }
                    }
                }
                catch (DirectoryServicesCOMException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}