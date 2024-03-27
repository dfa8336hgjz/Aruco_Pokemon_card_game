using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Monster_Type : MonoBehaviour
{
    public pokeType type;
    [HideInInspector]
    public int[] counter;
    [HideInInspector]
    public Sprite typeSymbol;
    private void Awake()
    {
        counter = new int[3];
    }
    void Start()
    {
        switch ((int)type)
        {
            case 0:
                counter[0] = 0; counter[1] = 1; counter[2] = -1;
                break;
            case 1:
                counter[0] = -1; counter[1] = 0; counter[2] = 1;
                break;
            case 2:
                counter[0] = 1; counter[1] = -1; counter[2] = 0;
                break;
            default:
                break;
        }

        Texture2D txt = LoadPNG(type);
        typeSymbol = Sprite.Create(txt, new Rect(0.0f, 0.0f, txt.width, txt.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public Texture2D LoadPNG(pokeType type)
    {
        string filePath = "Assets/Textures/" + type.ToString() + ".png";
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
        return tex;
    }

}
