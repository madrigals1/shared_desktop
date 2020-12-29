using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileManager : MonoBehaviour
{
    public string filename;
    TextMeshProUGUI format, content;
    Image formatImage, fileImage;
    Transform zoneHolder, move, fileHolder;
    public Transform handle;

    void Start()
    {
        fileHolder = transform.parent;
        zoneHolder = GameObject.Find("Zones").transform;
        format = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        formatImage = format.transform.parent.GetComponent<Image>();
        content = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        fileImage = GetComponent<Image>();
        move = transform.GetChild(1);
    }

    public void Init(string filename){
        Start();
        string f = Path.GetExtension(filename).Substring(1).ToUpper();
        ManagerFormatColor(f);
        format.text = f;
        this.filename = Path.GetFileNameWithoutExtension(filename);
        content.text = this.filename;
    }

    void ManagerFormatColor(string f){
        switch(f){
            case "JPG":
                formatImage.color = Values.ColorPalette[1];
                break;
            case "PNG":
                formatImage.color = Values.ColorPalette[2];
                break;
            case "TXT":
                formatImage.color = Values.ColorPalette[3];
                break;
            case "PDF":
                formatImage.color = Values.ColorPalette[4];
                break;
        }
    }

    void Update(){
        bool ol = false;
        foreach(Transform child in zoneHolder){
            if(child.GetComponent<RectTransform>().Overlaps(move.GetComponent<RectTransform>())){
                ol = true;
                transform.parent = child.GetChild(1);
                fileImage.color = child.GetComponent<ZoneManager>().color;
            }
        }
        if(!ol) {
            transform.parent = fileHolder;
            fileImage.color = Values.ColorPalette[Values.Colors.WHITE];
        }
    }
}
