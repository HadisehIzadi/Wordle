using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorizer : MonoBehaviour
{
	private keyboardkey[] keys;
	
	void Awake()
	{
		keys = GetComponentsInChildren<keyboardkey>();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Colorize(string secretWord , string wordToCheck)
    {
    	for (int i = 0; i < keys.Length; i++)
        {
    		char keyLetter = keys[i].GetLetter();
    		for (int j = 0; j < wordToCheck.Length; j++)
            {
    			 if (keyLetter != wordToCheck[j])
                    continue;
    			 if(keyLetter == secretWord[j])
                {
                    // Valid
                    keys[i].SetValid();
                }
                else if(secretWord.Contains(keyLetter))
                {
                    // Potential
                    keys[i].SetPotential();
                }
                else
                {
                    // Invalid
                    keys[i].SetInvalid();
                }
    			 
    		}
    	}
    }
    
    
    
    
}
