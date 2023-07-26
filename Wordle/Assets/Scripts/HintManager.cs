using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
	[Header(" Elements ")]
	[SerializeField] private GameObject keyboard;
	private keyboardkey[] keys;
    
    
    
	List<int> letterHintGivenIndices = new List<int>();
    

	private void Awake()
	{
		keys = keyboard.GetComponentsInChildren<keyboardkey>();
	}
    
	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
        
	}
    
	public void KeyboardHint()
	{
		//Debug.Log("its working ");
    	
		string secretWord = WordManager.instance.GetSecretWord();

		List<keyboardkey> untouchedKeys = new List<keyboardkey>();

		for (int i = 0; i < keys.Length; i++)
			if (keys[i].IsUntouched())
				untouchedKeys.Add(keys[i]);
        
		List<keyboardkey> t_untouchedKeys = new List<keyboardkey>(untouchedKeys);

		for (int i = 0; i < untouchedKeys.Count; i++)
			if (secretWord.Contains(untouchedKeys[i].GetLetter()))
				t_untouchedKeys.Remove(untouchedKeys[i]);
        
		if (t_untouchedKeys.Count <= 0)
			return;
        
		int randomKeyIndex = Random.Range(0, t_untouchedKeys.Count);
		t_untouchedKeys[randomKeyIndex].SetInvalid();

	}

	public void LetterHint()
	{
		//Debug.Log("its working ");
    	
		if (letterHintGivenIndices.Count >= 5) {
			// Debug.Log("All hints have been given");
			return;
		}
    	 
		List<int> letterHintNotGivenIndices = new List<int>();

		for (int i = 0; i < 5; i++)
			if (!letterHintGivenIndices.Contains(i))
				letterHintNotGivenIndices.Add(i);
        
    	 
		WordContainer currentWordContainer = InputManager.instance.GetCurrentWordContainer();

		string secretWord = WordManager.instance.GetSecretWord();

		int randomIndex = letterHintNotGivenIndices[Random.Range(0, letterHintNotGivenIndices.Count)];
		letterHintGivenIndices.Add(randomIndex);

		currentWordContainer.AddAsHint(randomIndex, secretWord[randomIndex]);

	}
}
