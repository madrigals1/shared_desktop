using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrashManager : MonoBehaviour
{
    public bool mouseOver;
    void Start()
    {
        OverrideOnPointerEnter ();
        OverrideOnPointerExit ();
    }

    void OverrideOnPointerEnter () {
        EventTrigger trigger = GetComponent<EventTrigger> ();
        EventTrigger.Entry entry = new EventTrigger.Entry ();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener ((data) => { OnPointerEnter ((PointerEventData) data); });
        trigger.triggers.Add (entry);
    }

    void OverrideOnPointerExit () {
        EventTrigger trigger = GetComponent<EventTrigger> ();
        EventTrigger.Entry entry = new EventTrigger.Entry ();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener ((data) => { OnPointerExit ((PointerEventData) data); });
        trigger.triggers.Add (entry);
    }

    public void OnPointerEnter (PointerEventData eventData) {
        mouseOver = true;
    }

    public void OnPointerExit (PointerEventData eventData) {
        mouseOver = false;
    }
}
