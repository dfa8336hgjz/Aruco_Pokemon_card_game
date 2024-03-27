using System;

[Serializable]
public class Action_data
{
    public string tags;
    public string description;

    public Action_data(Card_data card)
    {
        tags = card.tags;
        description = card.description;
    }
}