using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
        AddScore(0);
    }

    IEnumerator SpawnTargets()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, targets.Count);
            GameObject target = Instantiate(targets[index]);
            target.transform.position = SpawnPos();
            AddScore(5);
        }
    }

    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -2);
    }

    void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
