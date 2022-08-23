using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public GameObject player;
    public Text scoretext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score : " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            score++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            score++;
        }
    }
}
