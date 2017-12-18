using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class UserInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User{FirstName="Max",LastName="Nordahl",age=23,sex="Man",city="Västerås"},
                new User{FirstName="Esho",LastName="Odisho",age=21,sex="Man",city="Linköping"},
                new User{FirstName="Erik",LastName="Lind",age=23,sex="Man",city="Nyköping"},
                new User{FirstName="Ida",LastName="Holme",age=23,sex="Woman",city="Stockholm"},
                new User{FirstName="Tobias",LastName="Jonsson",age=25,sex="Man",city="Sundsvall"},
                new User{FirstName="Greger",LastName="Bengtsson",age=56,sex="Man",city="Umeå"},
                new User{FirstName="Anna-Karin",LastName="Svensson",age=58,sex="Woman",city="Göteborg"},
                new User{FirstName="Bogdan",LastName="Bogdanovic",age=43,sex="Man",city="Belgrad"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
                }
             }
         }
