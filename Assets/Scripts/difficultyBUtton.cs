using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyBUtton : MonoBehaviour
{
    public int difficulty;
    private Button _button;
    private GAMEmanager _gameManager;

    private void Awake()
    {
        _button = GetComponent<Button>();

        //per cada pic que cliqui a nes botó, s'afegirà sa funció Setdifficulty dins es botó
        _button.onClick.AddListener(SetDifficulty);
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GAMEmanager>();
    }

    private void SetDifficulty()
    {
        //se posarà sa pròpia 
        _gameManager.StartGame(difficulty);
    }
}
