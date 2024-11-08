using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }
    
    // Reference to LevelManager
    public LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Find LevelManager in the scene or create one if it doesn't exist
            LevelManager = FindObjectOfType<LevelManager>();
            if (LevelManager == null)
            {
                GameObject levelManagerObject = new GameObject("LevelManager");
                LevelManager = levelManagerObject.AddComponent<LevelManager>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

