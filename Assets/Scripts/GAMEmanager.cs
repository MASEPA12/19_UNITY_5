using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GAMEmanager : MonoBehaviour
{
    //instanciar objectes
    public GameObject[] targetPREFABS;
    public GameObject[] specialPREFABS;
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
  
    //variable per guardar punts
    private int score;

    //PANELS
    public GameObject startGamePanel;
    public GameObject gameOverPanel;

    //lives
    private int Lives = 5;
    public TextMeshProUGUI livesText;

    private void Start()
    {
        startGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    //funció game over
    public void GameOver()
    {
        isGameOver = true;
        //apareixer text de gameover
        gameOverPanel.SetActive(true);

    }

    //botó
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
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
            yield return new WaitForSeconds(spawnRate); //ESPERA FINS QUE PASIN 3 SEGONS
            int randomIndex = Random.Range(0, targetPREFABS.Length); //numero aleatori per triar s'objecte
            randomPos = RandomSpawnPosition(); //guard sa posició aleatoria que m'ha fet sa funcio randomSpawnPos
            while (targetPosInScene.Contains(randomPos)) //si dins sa llista hi ha sa posició que acaba de tocar, en cerc una altra
            {
                randomPos = RandomSpawnPosition();
            } //podré sortir des bucle quan sa randomPos no estigui dins sa llista
            
        Instantiate(targetPREFABS[randomIndex], randomPos, targetPREFABS[randomIndex].transform.rotation);
        targetPosInScene.Add(randomPos); //afegir sa posició on acabam de posar un element dins sa llista
            
        }
    }

    //cada vegada que guanyem punts, sobreescriu score, sumant es punts que ha guanyat (newPoints) pitjant
    public void updateScore(int newPoints)
    {
        score += newPoints;
        scoreText.text = $"SCORE: {score}";
    }

    //funció start game, que prepara sa escena de bell nou
    public void StartGame(int difficulty)
    {
        isGameOver = false;
        score = 0;
        spawnRate /= difficulty;

        Lives = 5;
        //livesText = $"Lives : {Lives}";

        //text; just in the beninging is showing the score
        scoreText.text = $"SCORE:{score}";
        StartCoroutine(SpawnRandomTarget());
        startGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    //restar una vida cada vegada que toqui una calavera
    public void MinusLives()
    {
        Lives--;
        if(Lives <= 0)
        {
            GameOver();
        }
    }

    /*public void RecoverLives()
    {
        Lives++;
    }*/
}
