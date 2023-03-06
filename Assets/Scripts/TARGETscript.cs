using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TARGETscript : MonoBehaviour
{
    //comunicacio entre scripts
    private GAMEmanager gameManager;

    //points --> sense res per poder asignar un valor a cada element
    public int points;

    private float lifeTime = 2f;

    void Start()
    {   //the object will destroy in "lifeTime" seconds
        Destroy(gameObject, lifeTime);

        //script comunications
        gameManager = FindObjectOfType<GAMEmanager>();
    }

    //if we click the collider of the game object que te aquest script asignat, destroy
    private void OnMouseDown()
    {//posam aquest if abans perquè si estic morta no pugui pitjar  
        if (!gameManager.isGameOver) //si estic viu i pitj sa cosa, sum es punts, a no ser que tengui sa tag bad, que me moriré
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.MinusLives();
            }
            if (gameObject.CompareTag("Pill"))
            {
                gameManager.RecoverLives();
            }
            gameManager.updateScore(points);
            Destroy(gameObject);

        }

    }

    //as soon as the object is destroyed, it's position is removed from the list
    private void OnDestroy()
    {
        gameManager.targetPosInScene.Remove(transform.position);
    }
}
