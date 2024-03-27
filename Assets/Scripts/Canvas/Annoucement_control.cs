using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Annoucement_control : MonoBehaviour
{
    public static Annoucement_control annoucement;

    [SerializeField] private TextMeshProUGUI announceText;
    [SerializeField] private GameObject background;
    private void Awake()
    {
        annoucement = GetComponent<Annoucement_control>();
        background.SetActive(false);
    }

    public void setAnnounce(string text)
    {
        StartCoroutine(displayText(text));
    }

    private IEnumerator displayText(string text)
    {
        announceText.text = text;
        background.SetActive(true);
        yield return new WaitForSeconds(2);
        announceText.text = "";
        background.SetActive(false);
    }
}
