using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
	[Header("elements")]
	[SerializeField] private string secretWord;
	
	// make this class singletone
	public static WordManager instance;
	
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string GetSecretWord()
    {
    	return secretWord.ToUpper();
    }
}
