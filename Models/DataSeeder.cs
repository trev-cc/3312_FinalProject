using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuffteksWebsite.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BuffteksWebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {

                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Greg", LastName="Rule", CompanyName="ACME", Email="grule@acme.com", Phone="555-555-5555" },
                    new Client { FirstName="Sundar", LastName="Pichai", CompanyName="Google", Email="spichai@google.com", Phone="555-555-5555" },
                    new Client { FirstName="David", LastName="Terry", CompanyName="ChopChop", Email="davidterry@chopchoprice.com", Phone="555-555-5555" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Trevor", LastName="Fleeman", Major="CIS", Email="tefleeman1@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Kiki", LastName="Alonzo", Major="CIS", Email="aalonzo1@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Dymell", LastName="Jones", Major="CIS", Email="djones1@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Brett", LastName="Ponder", Major="CIS", Email="tveith1@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Ian", LastName="Bilek", Major="CIS", Email="ibilek1@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Gabby", LastName="Ashely", Major="CIS", Email="gashely@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Amy", LastName="noidea", Major="CIS", Email="anoidea1@buffs.wtamu.edu", Phone="555-555-5555" }
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="Chop Chop", ProjectDescription="The main project for 2018/2019 year" },
                    new Project { ProjectName="Awesome", ProjectDescription="This project is awesome" },
                    new Project { ProjectName="Beginners", ProjectDescription="This project is to help beginners establish their skill base for reference when working with BuffTeks" }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                

            }
        }
    }
}