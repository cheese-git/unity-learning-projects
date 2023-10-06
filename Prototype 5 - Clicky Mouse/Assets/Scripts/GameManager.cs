using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    int score = 0;
    bool isGameActive;
    int difficulty;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AddScore(0);
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1f / difficulty);
            int index = Random.Range(0, targets.Count);
            GameObject target = Instantiate(targets[index]);
            target.transform.position = SpawnPos();
        }
    }

    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -2);
    }

    public void AddScore(int scoreToAdd)
    {
        if (isGameActive)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
    }

    public void StartGame(int difficulty)
    {
        this.difficulty = difficulty;
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnTargets());
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
