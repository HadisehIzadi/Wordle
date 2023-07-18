using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LetterContainer : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private TextMeshPro letter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Initialize()
    {
    	letter.text = " ";
    }
    
    public void SetLetter(char letter)
    {
    	this.letter.text = letter.ToString();
    }
    
    public char Getletter()
    {
    	return this.letter.text[0];
    }
}
