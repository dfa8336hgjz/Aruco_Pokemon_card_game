using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSupport : MonoBehaviour
{
    [HideInInspector]
    public Card_data[] cards;

    public Dictionary<int, Monster_data> monsters = new Dictionary<int, Monster_data>();
    public Dictionary<int, Action_data> actions = new Dictionary<int, Action_data>();

    private void Awake()
    {
        LoadJSON();
    }
    void LoadJSON()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/card_data.json");
        Card_data_list data = JsonUtility.FromJson<Card_data_list>(json);
        cards = data.list;
        for(int i = 0; i < cards.Length; i++)
        {
            if (cards[i].tags == "monster")
                monsters.Add(i, new Monster_data(cards[i]));
            else actions.Add(i, new Action_data(cards[i]));
        }
    }
}
