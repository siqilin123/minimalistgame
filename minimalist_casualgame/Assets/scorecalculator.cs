using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    //public GameObject player;
    public Text scoretext2;
    public Text scoretext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score : " + score.ToString();
        scoretext2.text = "Score : " + score.ToString();
    }

    
}
