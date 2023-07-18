using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private WordContainer[] wordContainers;
	[SerializeField] Button tryButton;
	
	[Header("settings")]
	int currentWordIndex;
	bool canAddletter = true;
    // Start is called before the first frame update
    void Start()
    {
    	Initialize();
    	keyboardkey.onKeyPressed += keyPressedCallBack;
    	currentWordIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Initialize()
    {
    	for(int i = 0 ; i < wordContainers.Length ; i++)
    		wordContainers[i].Initialize();
    }
    
    void keyPressedCallBack(char letter)
    {
    	if(!canAddletter)
    		return;
    	
    	wordContainers[currentWordIndex].Add(letter);
    	
    	if(wordContainers[currentWordIndex].IsComplete()){
    		//currentWordIndex++;
    		//CheckWord();
    		canAddletter = false;
    		EnableButton();
    	}
    	
    	
    }
    
   public void CheckWord()
    {
    	string wordToCheck = wordContainers[currentWordIndex].GetWord();
    	string secretWord = WordManager.instance.GetSecretWord();
    	
    	if(wordToCheck == secretWord)
    	{
    		Debug.Log("level complete");
    	}
    	else
    	{
    		currentWordIndex++;
    		Debug.Log("wrong word");
    		canAddletter = true;
    		DisableButton();
    	}
    	
    }
   
   public void backSpacePress()
   {
   	bool removeLetter = wordContainers[currentWordIndex].Removeletter();
   	if(removeLetter)
   		DisableButton();
   	canAddletter = true;
   }
   
   void EnableButton()
   {
   	tryButton.interactable  = true;
   }
   void DisableButton()
   {
   	tryButton.interactable  = false;
   }
      
}
