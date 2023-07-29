using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HepticManager : MonoBehaviour
{
    public static HepticManager instance;

    [Header(" Settings ")]
    private bool haptics;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EnableHaptics()
    {
        haptics = true;
    }

    public void DisableHaptics()
    {
        haptics = false;
    }

    public bool HapticsEnabled()
    {
        return haptics;
    }

    public static void Vibrate()
    {
        if (instance.HapticsEnabled())
        {
            // Taptic.Light
        }
    }
}
