using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] info = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonhealth = int.Parse(info[3]);
                int badges = 0;
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonhealth);
                var trainer = new Trainer(trainerName, badges, new List<Pokemon> { pokemon });
                int index = trainers.FindIndex(x => x.Name == trainerName);
                if (index != -1)
                {
                    trainers[index].Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(trainer);
                }
                
            }
            while ((command = Console.ReadLine()) != "End")
            {
                string givenElement = command;
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == givenElement))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }               
            }

            var ordered = trainers.OrderByDescending(x => x.Badges).ToList();
            ordered.ForEach(x => Console.WriteLine($"{x.Name} {x.Badges} {x.Pokemons.Count}"));
        }
    }
}
