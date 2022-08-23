using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button restart;
    public Button share;
    public GameObject bulletprefab;
    private float shootTime;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        shootTime = shootTime - Time.deltaTime;
        if (shootTime < 0)
        {
            Firebullet();
            shootTime = 2;
        }

    }

    private void Firebullet()
    {
        
        Instantiate(bulletprefab, new Vector2(10, 10), Quaternion.identity);
    }
}
