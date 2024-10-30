using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestUIBInd : UIBInder
{
    // Start is called before the first frame update
    void Awake()
    {
        BindAll();
    }

    private void Start()
    {
        GetUI<Text>("TestText").text = "10";
        AddEvent("TestText", EventType.Click, Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(PointerEventData eventData)
    {
        Debug.Log("TextTest");
    }
}
