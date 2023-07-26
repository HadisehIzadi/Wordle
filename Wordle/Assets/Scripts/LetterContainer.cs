using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LetterContainer : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private TextMeshPro letter;
	[SerializeField] SpriteRenderer lettercontainer;
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
    	lettercontainer.color = Color.white;
    }
    
    public void SetLetter(char letter, bool isHint = false)
    {
        if (isHint)
            this.letter.color = Color.gray;
        else
            this.letter.color = Color.black;


        this.letter.text = letter.ToString();
    }
    
    public char Getletter()
    {
    	return this.letter.text[0];
    }
    
   public void SetValid()
   {
   	lettercontainer.color = Color.green;
   }
   
   public void SetPotentail()
   {
   	lettercontainer.color = Color.yellow;
   }
   
   public void SetInvalid()
   {
   	lettercontainer.color = Color.gray;
   }
}
