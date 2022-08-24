using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button restart;
    public Button share;
    public GameObject bulletprefab;
    public GameObject player;
    private float shootTime;
    public static bool isshared;
    //private float timepast;

    void Start()
    {
        restart.onClick.AddListener(reloadbutton);
        share.onClick.AddListener(sharebutton);
        if (isshared)
        {
            player.transform.localScale = new Vector3(0.5f, 3, 1);
        }
        //timepast = Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        shootTime = shootTime - Time.deltaTime;
        if (shootTime < 0)
        {
            Firebullet();
            shootTime = 1.5f;
        }

    }

    private void Firebullet()
    {
        Vector2 offset = Random.onUnitSphere * Random.Range(3, 10);
        //var radians =  2*Mathf.PI / num*i
        //var spawndir = new Vector3 (Mathf.Cos(radian))
        Instantiate(bulletprefab, new Vector2(offset.x, offset.y), Quaternion.identity);
    }

    private void reloadbutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void sharebutton()
    {
        isshared = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
