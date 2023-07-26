using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private string secretWord;
	[SerializeField] private TextAsset wordsText;
	private string words;
	
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
    	SetNewSecretWord();
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
    }
}
