using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordContainer : MonoBehaviour
{
	[Header("elements")]
	private LetterContainer[] letterContainers;
	
	[Header("settings")]
	int currentletterIndex;
	
	void Awake()
	{
		letterContainers = GetComponentsInChildren<LetterContainer>();
		//Initialize();
	}
    // Start is called before the first frame update
    void Start()
    {
    	currentletterIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void Initialize()
    {
    	for(int i = 0 ;  i < letterContainers.Length ; i++)
    		letterContainers[i].Initialize();
    	
    }
   public void Add(char letter)
   {
   	letterContainers[currentletterIndex].SetLetter(letter);
   	currentletterIndex++;
   }
   
   public bool IsComplete()
   {
   	return currentletterIndex >= 5;
   }
   
   public string GetWord()
   {
   	string word ="";
   	for(int i = 0 ; i < letterContainers.Length ; i++)
   	{
   		word += letterContainers[i].Getletter().ToString();
   	}
   	
   	return word;
   }
   
   public bool Removeletter()
   {
   	if(currentletterIndex <= 0)
   		return false;
   	currentletterIndex--;
   	letterContainers[currentletterIndex].Initialize();
   	return true;
   }
}