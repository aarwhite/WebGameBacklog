using System;

namespace WebGameBacklog.Domain.Games
{
    public class CreateGameDto
    {
        public string Name { get; set; }

        public Platform Plateform { get; set; }

        public string TimeToComplete { get; set; } 

        public DateTime DateAdded { get; set; }
    }
}
