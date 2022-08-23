using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject gameoverscreen;

    void Start()
    {
        gameoverscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gameover();
    }

    private void Gameover()
    {
        gameoverscreen.SetActive(true);
        Time.timeScale = 0;
    }
}
