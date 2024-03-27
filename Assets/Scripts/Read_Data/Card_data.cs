using System;

[Serializable]
public class Card_data
{
    public string tags;
    public string description;
    public string[] names;
    public int[] lvEvol;
    public int type;
    public int[] attack;
    public int[] health;
}

[Serializable]
public class Card_data_list
{
    public Card_data[] list;
}