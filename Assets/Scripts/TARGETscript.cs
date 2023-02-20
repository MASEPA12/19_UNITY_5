using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TARGETscript : MonoBehaviour
{
    //comunicacio entre scripts
    private GAMEmanager gameManager;

    //points
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
    {
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.isGameOver = true;
        }
        Destroy(gameObject);
    }

    //as soon as the object is destroyed, it's position is removed from the list
    private void OnDestroy()
    {
        gameManager.targetPosInScene.Remove(transform.position);
    }
}
