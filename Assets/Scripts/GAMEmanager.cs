using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GAMEmanager : MonoBehaviour
{
    //instanciar objectes
    public GameObject[] targetPREFABS;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float betweenSquares = 2.5f;

    //lògica general
    public bool isGameOver;
    public float spawnRate = 2f;
    public List<Vector3> targetPosInScene;
    public Vector3 randomPos;

    //text
    public TextMeshProUGUI scoreText;
    private int score;

    
    private void Start()
    {
        isGameOver = false;
        StartCoroutine("SpawnRandomTarget");

        //text
        scoreText.text = $"SCORE:{score}";
    }

    //instanciar objectes
    private Vector3 RandomSpawnPosition()
    {
        // x + (numero aleatòri entre 0-4 * distància entre quadrats)=bot 
        float spawnPosX = minX + Random.Range(0, 4) * betweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) * betweenSquares;

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    //logica general
    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPREFABS.Length);
            randomPos = RandomSpawnPosition();
            while (targetPosInScene.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }
            
        Instantiate(targetPREFABS[randomIndex], randomPos, targetPREFABS[randomIndex].transform.rotation);
        targetPosInScene.Add(randomPos);
        }
    }

    public void updateScore(int newPoints)
    {
        score += newPoints;
        scoreText.text = $"SCORE: {score}";
    }

}
