using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class keyboardkey : MonoBehaviour
{
	[Header("elements")]
	public TextMeshProUGUI letterText;
	
	[Header("events")]
	public static Action<char> onKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
    	GetComponent<Button>().onClick.AddListener(SendKeyPressEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SendKeyPressEvent()
    {
    	onKeyPressed?.Invoke(letterText.text[0]);
    	//Debug.Log(letterText.text);
    }
}
