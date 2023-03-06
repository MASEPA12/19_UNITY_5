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

        //per cada pic que cliqui a nes bot�, s'afegir� sa funci� Setdifficulty dins es bot�
        _button.onClick.AddListener(SetDifficulty);
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GAMEmanager>();
    }

    private void SetDifficulty()
    {
        //se posar� sa pr�pia 
        _gameManager.StartGame(difficulty);
    }
}
