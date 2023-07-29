using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private WordContainer[] wordContainers;
	[SerializeField] Button tryButton;
	[SerializeField] private KeyboardColorizer keyboardColorizer;
	
	
	[Header("settings")]
	int currentWordIndex;
	bool canAddletter = true;
	private bool shouldReset;
	
	[Header(" Events ")]
    public static Action onLetterAdded;
    public static Action onLetterRemoved;
	public static InputManager instance;
	
	
	private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
	
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
                
                if(shouldReset)
                    Initialize();
                break;

            case GameState.LevelComplete:
                shouldReset = true;
                break;

            case GameState.Gameover:
                shouldReset = true;
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
		
		shouldReset = false;
		
	}
    
	void keyPressedCallBack(char letter)
	{
		if (!canAddletter)
			return;
    	
		wordContainers[currentWordIndex].Add(letter);
    	HepticManager.Vibrate();
    	
		if (wordContainers[currentWordIndex].IsComplete()) {
			//currentWordIndex++;
			//CheckWord();
			canAddletter = false;
			EnableButton();
		}
    	
    	onLetterAdded?.Invoke();
    	
    	
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
                //DataManager.instance.ResetScore();
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
		onLetterRemoved?.Invoke();
	}
   
   
	void EnableButton()
	{
		tryButton.interactable = true;
	}
	void DisableButton()
	{
		tryButton.interactable = false;
	}
	
	public WordContainer GetCurrentWordContainer()
    {
        return wordContainers[currentWordIndex];
    }
      
}
