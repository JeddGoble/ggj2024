using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject[] levelArray;
    [SerializeField] private UIManager uiManager;

    public int currentLevelNumber = 1;
    public int volunteersRemaining;
    private GameObject currentLevel;


    private void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        LoadLevel(currentLevelNumber);
    }

    private void LoadLevel(int levelNum) 
    {
        
        if (levelNum >= levelArray.Length) 
        {
            return;
        }
        
        GameObject level = levelArray[levelNum];
        LevelData levelData = level.GetComponent<LevelData>();
        volunteersRemaining = levelData.volunteersAvailable;
        uiManager.UpdateCounter(volunteersRemaining);

        currentLevel = Instantiate(level, Vector3.zero, Quaternion.identity);
    }

    public void SpawnedVolunteer() 
    {
        volunteersRemaining--;
        uiManager.UpdateCounter(volunteersRemaining);
    }

    public void GoalTouched() 
    {
        // currentLevel.SetActive(false);
        uiManager.LevelWin();
    }

}
