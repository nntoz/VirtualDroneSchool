using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class learning : MonoBehaviour
{
    [Header("実践のリスト")]
    public List<string> intext;
    public List<GameObject> torus;
    public List<string> restriction;
    [Header("指定")]
    public TextMeshProUGUI text;
    public int nowSection;
    // Start is called before the first frame update
    void Start()
    {
        text.text = intext[nowSection];
        torus[nowSection].SetActive(true);
    }
    public void nextSection()
    {
        Debug.Log("通過");
        text.text = "";
        torus[nowSection].SetActive(false);
        
        nowSection = (nowSection % intext.Count + 1) % intext.Count;
        text.text = intext[nowSection];
        torus[nowSection].SetActive(true);
    }

    
}
