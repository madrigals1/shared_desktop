using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneManager : MonoBehaviour
{
    public string zonename;
    TextMeshProUGUI title;
    Image self, head;
    public Color color;
    public Transform handle;

    void Start()
    {
        title = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        self = GetComponent<Image>();
        head = transform.GetChild(0).GetComponent<Image>();
    }

    public void Init(string text, Color color){
        Start();
        SetTitle(text);
        SetColor(color);
    }

    void SetTitle(string text){
        zonename = text;
        title.text = text;
    }

    void SetColor(Color color){
        self.color = color;
        head.color = color;
        this.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
