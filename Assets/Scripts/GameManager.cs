using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    private static GameManager _instance;
    
    private GameObject _player;
    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        
        Cursor.lockState = CursorLockMode.Locked;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetPlayer() => _player;

    public void StopGame()
    {
        Time.timeScale = 0;
    }
    
}
