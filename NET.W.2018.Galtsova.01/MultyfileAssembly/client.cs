using System;
using Pokemon;

class Program 
{
    static void Main()
    {
        PokemonType pokemon = new PokemonType();
        pokemon.PokemonTypeInfo();

        ElectricPokemon electricPokemon = new ElectricPokemon();
        electricPokemon.ElectricPokemonInfo();
    }
}