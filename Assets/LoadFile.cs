using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFile : MonoBehaviour {
    public TextAsset textFile;
	// Use this for initialization
	void Start () {
        string text = textFile.text;
        Debug.Log(text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
