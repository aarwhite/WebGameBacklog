using System;
using WebGameBacklog.Shared.Persistence;

namespace WebGameBacklog.Domain.Games
{
    public class Game : Entity
    {
        private Game(CreateGameDto createGameDto)
        {
            Name = createGameDto.Name;
            TimeToComplete = createGameDto.TimeToComplete;
            Plateform = createGameDto.Plateform;
            DateAdded = createGameDto.DateAdded;
            State = GameState.NotStarted;
        }

        public Guid Id { get; protected set; }
        
        public string Name { get; protected set; }

        public string TimeToComplete { get; protected set; }

        public DateTime DateAdded { get; protected set; }

        public DateTime? DateStarted { get; protected set; }

        public DateTime? DateCompleted { get; protected set; }

        public GameState State { get; protected set; }
     
        public Platform Plateform { get; protected set;} 

        public static Game Create(CreateGameDto createGameDto)
        {
            if(createGameDto == null)
            {
                throw new ArgumentNullException(nameof(createGameDto));
            }

            if(createGameDto.Name == null)
            {
                throw new ArgumentException("Name is required");
            }

            if (createGameDto.DateAdded < new DateTime(2016, 01, 01))
            {
                throw new ArgumentException("DateAdded");
            }

            if (createGameDto.Plateform == Platform.Unknown)
            {
                throw new ArgumentException("Plateform Unknown");
            }

            return new Game(createGameDto);
        }
    }
}
