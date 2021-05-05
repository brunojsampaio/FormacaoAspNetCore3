using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Bruno", "bruno@gmail.com", new DateTime(1980, 01, 01)),
                new User("Maria", "maria@gmail.com", new DateTime(1950, 01, 01)),
                new User("José", "jose@gmail.com", new DateTime(1960, 01, 01))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}