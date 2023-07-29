using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private string secretWord;
	[SerializeField] private TextAsset wordsText;
	private string words;
	
	
	[Header(" Settings ")]
    private bool shouldReset = true;
    
	// make this class singletone
	public static WordManager instance;
	
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		words = wordsText.text;
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
    	 GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string GetSecretWord()
    {
    	return secretWord.ToUpper();
    }
    
    
    private void SetNewSecretWord()
    {
        Debug.Log("String length : " + words.Length);
        int wordCount = (words.Length + 2) / 7;

        int wordIndex = Random.Range(0, wordCount);

        int wordStartIndex = wordIndex * 7;

        secretWord = words.Substring(wordStartIndex, 5).ToUpper();
        
        shouldReset = false;
    }
    
    
    
    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:

               

                break;

            case GameState.Game:

                if (shouldReset)
                    SetNewSecretWord();

                break;

            case GameState.LevelComplete:
                shouldReset = true;
                break;

            case GameState.Gameover:
                shouldReset = true;
                break;
        }
    }
}
