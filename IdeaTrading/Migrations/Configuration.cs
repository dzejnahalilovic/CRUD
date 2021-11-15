namespace IdeaTrading.Migrations
{
    using IdeaTrading.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeaTrading.Context.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdeaTrading.Context.MyDbContext context)
        {

            context.User.AddOrUpdate(
              u => u.FirstName,
              new User { FirstName = "Andrew", LastName = "Peters", Address = "address1", City = "London", DateOfEmployment = DateTime.Now, Position = "Software Developer", Phone = "+111 2321 232 22"},
              new User { FirstName = "Brice", LastName = "Lambson", Address = "address2", City = "Berlin", DateOfEmployment = DateTime.Now, Position = "Graphic Designer", Phone = "+123 79 345 678" },
              new User { FirstName = "Rowan", LastName = "Miller", Address = "address3", City = "London", DateOfEmployment = DateTime.Now, Position = "Sale Manager", Phone = "+111 2321 232 22" }
            );

        }
    }
}
