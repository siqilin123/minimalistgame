using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    private GameObject gameoverscreen;
    public scorecalculator scorecalculatorscript;
    public GameObject explosionprefab;
    void Start()
    {
        //GameObject bullet = this.gameObject;
        target = GameObject.FindGameObjectWithTag("life");
        gameoverscreen = GameObject.FindGameObjectWithTag("ui").transform.Find("gameover_panel").gameObject;
        scorecalculatorscript = GameObject.FindGameObjectWithTag("player").GetComponent<scorecalculator>();
        //gameoverscreen.SetActive(false);
        
        //bullet.transform.rotation = Quaternion.LookRotation(targetpos);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bullet = this.gameObject;
        Vector3 targetpos = target.transform.position;
        Vector2 direction = (transform.position - targetpos).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, 6f* Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));

        //if(target = null)
        //{
         //   Destroy(gameObject);
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "life")
        {
            Gameover();
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
            Instantiate(explosionprefab, transform.position, Quaternion.identity);
            scorecalculatorscript.score++;
        }

    }

    private void Gameover()
    {
        gameoverscreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
            scorecalculatorscript.score++;
        }
    }
}
