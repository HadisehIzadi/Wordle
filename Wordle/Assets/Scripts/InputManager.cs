using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private WordContainer[] wordContainers;
	[SerializeField] Button tryButton;
	[SerializeField] private KeyboardColorizer keyboardColorizer;
	[Header("settings")]
	int currentWordIndex;
	bool canAddletter = true;
	
	
	// Start is called before the first frame update
	void Start()
	{
		Initialize();
		keyboardkey.onKeyPressed += keyPressedCallBack;
		currentWordIndex = 0;
        
	        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        keyboardkey.onKeyPressed -= keyPressedCallBack;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }
    
    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
                Initialize();
                break;

            case GameState.LevelComplete:

                break;
        }
    }

	// Update is called once per frame
	void Update()
	{
        
	}
    
	void Initialize()
	{
		currentWordIndex = 0;
        canAddletter = true;

        DisableButton();
        
		for (int i = 0; i < wordContainers.Length; i++)
			wordContainers[i].Initialize();
	}
    
	void keyPressedCallBack(char letter)
	{
		if (!canAddletter)
			return;
    	
		wordContainers[currentWordIndex].Add(letter);
    	
		if (wordContainers[currentWordIndex].IsComplete()) {
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

        wordContainers[currentWordIndex].Colorize(secretWord);
        keyboardColorizer.Colorize(secretWord, wordToCheck);

        if (wordToCheck == secretWord)
        {
            SetLevelComplete();
        }
        else
        {
            Debug.Log("Wrong word");
            currentWordIndex++;
            DisableButton();            

            if(currentWordIndex >= wordContainers.Length)
            {
                //Debug.Log("Gameover");
                DataManager.instance.ResetScore();
                GameManager.instance.SetGameState(GameState.Gameover);
            }
            else
            {
                canAddletter = true;
            }

        }
    	
	}
   
	private void SetLevelComplete()
	{
		UpdateData();
		GameManager.instance.SetGameState(GameState.LevelComplete);
	}
	private void UpdateData()
	{
		int scoreToAdd = 6 - currentWordIndex;

		DataManager.instance.IncreaseScore(scoreToAdd);
		DataManager.instance.AddCoins(scoreToAdd * 3);
	}
    
   
	public void backSpacePress()
	{
		//if (!GameManager.instance.IsGameState())
          //  return;
		
		bool removeLetter = wordContainers[currentWordIndex].Removeletter();
		if (removeLetter)
			DisableButton();
		canAddletter = true;
	}
   
   
	void EnableButton()
	{
		tryButton.interactable = true;
	}
	void DisableButton()
	{
		tryButton.interactable = false;
	}
      
}
