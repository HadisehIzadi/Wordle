using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	keyboardkey.onKeyPressed += DebugLettere;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void DebugLettere(char let)
    {
    	Debug.Log(let);
    }
}
