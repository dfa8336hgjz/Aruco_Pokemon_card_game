using System;

public enum pokeType
{
    fire, 
    grass,
    water
}

[Serializable]
public class Monster_data
{
    public string tags;
    public string[] names;
    public int[] lvEvol;
    public pokeType type;
    public int[] attack;
    public int[] health;

    public Monster_data(Card_data card)
    {
        tags = card.tags;
        names = card.names;
        lvEvol = card.lvEvol;
        type = (pokeType)card.type;
        attack = card.attack;
        health = card.health;
    }
}