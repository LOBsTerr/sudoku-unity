using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    [SerializeField]
    public int xIndex;
    [SerializeField]
    public int yIndex;

    public Layout Layout { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse clicked on " + gameObject.name);
        Debug.Log("Mouse clicked on " + xIndex);
        Debug.Log("Mouse clicked on " + yIndex);

        this.Layout.SetSelectedItem(this);
    }

    public void Init(Layout layout) { 
        Layout = layout;
    }
}
