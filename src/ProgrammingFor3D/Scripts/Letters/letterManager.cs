using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class letterManager : MonoBehaviour
{
    public List<letterCreator> letters = new List<letterCreator>();
    public GameObject letterPrefab;

    private void Start()
    {
        GameObject letter = Instantiate(letterPrefab);
        if (letters.Count >= 1)
        {
            letter.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = letters[0].letterTitle;
            letter.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = letters[0].letterTask;

            letters.RemoveAt(0);
        }
    }
}
