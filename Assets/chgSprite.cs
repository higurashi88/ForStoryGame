using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour {
    public Sprite one;
    public Sprite two;

	// Use this for initialization
	void Start () {
	}	
	// Update is called once per frame
	void Update () {	
	}
    public void changeSprite()
    {
        this.gameObject.GetComponent<Image>().sprite = two;
    }
}
