using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleFileBrowser;

public class Main : MonoBehaviour
{
    // Red orange yellow green blue purple pink black
    public Button btnAddZone, btnColorpicker, btnUpload, btnYes, btnNo;
    public Transform pnlColorpicker, zoneHolder, fileHolder;
    public ZoneManager prefabZone;
    public FileManager prefabFile;
    public Transform[] colors;
    public TMP_InputField ifName;
    public FileManager currentDeleteFile;
    public ZoneManager currentDeleteZone;
    public Transform trashCan, popupPanels;
    public TextMeshProUGUI deleteText;
    
    void Start()
    {
        SetOnClickListeners();
        SetColors();
    }

    void SetColors(){
        for(int i = 0; i < colors.Length; i++){
            colors[i].GetChild(0).GetComponent<Image>().color = Values.ColorPalette[i];
            int locali = i;
            colors[i].GetComponent<Button>().onClick.AddListener(() => SetCurrentColor(locali));
        }
    }

    void SetCurrentColor(int i){
        Values.Colors.CURRENT = i;
        btnColorpicker.transform.GetChild(0).gameObject.SetActive(false);
        btnColorpicker.transform.GetChild(1).gameObject.SetActive(true);
        btnColorpicker.transform.GetChild(1).GetComponent<Image>().color = Values.ColorPalette[Values.Colors.CURRENT];
        ToggleColorpicker();
    }

    void SetOnClickListeners(){
        btnColorpicker.onClick.AddListener(() => ToggleColorpicker());
        btnAddZone.onClick.AddListener(() => AddZone());
        btnUpload.onClick.AddListener(() => AddFile());
        btnYes.onClick.AddListener(() => DeleteFile(true));
        btnNo.onClick.AddListener(() => DeleteFile(false));
    }

    void AddFile(){
        FileBrowser.SetFilters( true, new FileBrowser.Filter( "Images", ".jpg", ".png" ), new FileBrowser.Filter( "Text Files", ".txt", ".pdf" ) );
        FileBrowser.SetDefaultFilter( ".jpg" );
		FileBrowser.SetExcludedExtensions( ".lnk", ".tmp", ".zip", ".rar", ".exe" );
		FileBrowser.AddQuickLink( "Users", "C:\\Users", null );
		StartCoroutine( ShowLoadDialogCoroutine() );
    }

    IEnumerator ShowLoadDialogCoroutine()
	{
		yield return FileBrowser.WaitForLoadDialog( false, null, "Load File", "Load" );
		if( FileBrowser.Success )
		{
			byte[] bytes = FileBrowserHelpers.ReadBytesFromFile( FileBrowser.Result );
            AddFile(FileBrowser.Result);
		}
	}

    void AddZone(){
        ZoneManager zm = Instantiate(prefabZone, zoneHolder) as ZoneManager;
        zm.Init(ifName.text, Values.GetCurrentColorAdjusted());
    }

    void AddFile(string filename){
        FileManager fm = Instantiate(prefabFile, fileHolder) as FileManager;
        fm.Init(filename);
    }

    void ToggleColorpicker(){
        pnlColorpicker.gameObject.SetActive(!pnlColorpicker.gameObject.activeSelf);
    }

    public void OpenDeletePopup(){
        popupPanels.gameObject.SetActive(true);
        if(currentDeleteFile != null){
            currentDeleteFile.gameObject.SetActive(false);
            deleteText.text = "Уверены что хотите удалить файл " + currentDeleteFile.filename +"?";
        }
        if(currentDeleteZone != null){
            currentDeleteZone.gameObject.SetActive(false);
            deleteText.text = "Уверены что хотите удалить папку " + currentDeleteZone.zonename +"?";
        }
    }

    void DeleteFile(bool delete){
        if(delete){
            if(currentDeleteFile != null) Destroy(currentDeleteFile.gameObject);
            if(currentDeleteZone != null) Destroy(currentDeleteZone.gameObject);
        } else {
            if(currentDeleteFile != null) {
                currentDeleteFile.transform.position = currentDeleteFile.handle.GetComponent<UIElementDragger>().lastPosition;
                currentDeleteFile.gameObject.SetActive(true);
                currentDeleteFile = null;
            }
            if(currentDeleteZone != null) {
                currentDeleteZone.transform.position = currentDeleteZone.handle.GetComponent<UIElementDragger>().lastPosition;
                currentDeleteZone.gameObject.SetActive(true);
                currentDeleteZone = null;
            }
        }
        popupPanels.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
