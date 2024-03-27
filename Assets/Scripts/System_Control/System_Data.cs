using System;

[Serializable]
public class System_Data
{
    public string tags;

    public System_Data(Card_data card)
    {
        tags = card.tags;
    }
}
