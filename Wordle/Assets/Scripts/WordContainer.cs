using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordContainer : MonoBehaviour
{
	[Header("elements")]
	private LetterContainer[] letterContainers;
	
	void Awake()
	{
		letterContainers = GetComponentsInChildren<LetterContainer>();
		Initialize();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Initialize()
    {
    	for(int i = 0 ;  i < letterContainers.Length ; i++)
    		letterContainers[i].Initialize();
    	
    }
}
