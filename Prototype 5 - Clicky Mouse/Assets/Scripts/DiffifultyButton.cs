using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffifultyButton : MonoBehaviour
{
    public int difficulty;
    GameManager gameManager;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => gameManager.StartGame(difficulty));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
