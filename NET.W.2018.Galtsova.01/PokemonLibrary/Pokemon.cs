using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLibrary
{
    public class Pokemon
    {
        public string pokemonName { get; set; }
        public string pokemonType { get; set; }
        public string pokemonDescription { get; set; }

        public Pokemon(string pokemonName, string pokemonType, string pokemonDescription)
        {
            this.pokemonName = pokemonName;
            this.pokemonType = pokemonType;
            this.pokemonDescription = pokemonDescription;
        }
    }
}
