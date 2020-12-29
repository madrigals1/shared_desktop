using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : EventTrigger {

    private bool dragging;
    public Transform element;
    public Vector2 difference;
    public Vector3 lastPosition = new Vector3(0,0,0);
    Main main;

    void Start(){
        element = transform.parent;
        if(element.GetComponent<ZoneManager>() != null) element.GetComponent<ZoneManager>().handle = transform;
        if(element.GetComponent<FileManager>() != null) element.GetComponent<FileManager>().handle = transform;
        main = GameObject.Find("Canvas").GetComponent<Main>();
    }

    public void Update() {
        if (dragging) {
            element.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + difference;
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        lastPosition = element.transform.position;
        dragging = true;
        difference = element.transform.position - Input.mousePosition;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
        if(main.trashCan.GetComponent<TrashManager>().mouseOver){
            if(transform.parent.GetComponent<ZoneManager>() != null){
                main.currentDeleteZone = transform.parent.GetComponent<ZoneManager>();
            }
            if(transform.parent.GetComponent<FileManager>() != null){
                main.currentDeleteFile = transform.parent.GetComponent<FileManager>();
            }
            main.OpenDeletePopup();
        }
    }
}