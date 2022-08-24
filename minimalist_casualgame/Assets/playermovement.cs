using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update

    //private Vector3 touchpos;
    public GameObject originobj;
    public GameObject player;
    public float rotationradius = 3f;
   

    void Start()
    {
        
        var go2 = new GameObject { name = "Circle", tag = "line" };
        
        //go2.transform.Rotate(0, 0, 0);
        go2.transform.Translate(originobj.transform.position);
        DrawCircle(go2, 3, 0.05f);

        player.transform.position = new Vector3(originobj.transform.position.x - 3f, 0, 0);
    }
    public float startAngle = 360.0f;
    public float angleTuchandX;    

    void Update()
    {
        GameObject go2 = GameObject.FindWithTag("line");
        go2.transform.position = originobj.transform.position;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 dir = mp - (Vector2)transform.position;

            angleTuchandX = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            startAngle = 360 + angleTuchandX;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 dir = mp - (Vector2)transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - startAngle;



            Handsoff();

            if (angle < transform.eulerAngles.z)
            {
                transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
        // Update is called once per frame
        void Handsoff()
    {

        //if(Input.touchCount > 0)
        //{
            
           // Debug.Log("touched");
        //}
        Touch touch = Input.GetTouch(0);
        Vector3 origin = originobj.transform.position;
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        Ray ray = Camera.main.ScreenPointToRay(touchPos);

        // Your raycast handling
        RaycastHit vHit;
        if (Physics.Raycast(ray.origin, ray.direction, out vHit))
        {
            if (vHit.transform.tag == "line")
            {
                //Destroy(vHit.collider.gameObject);
                Vector3 v = touchPos - origin;
                Vector3 new_pos = origin + v.normalized * rotationradius;
                player.transform.position = new_pos;
            }
  

        }


    }

     private void DrawCircle(GameObject container, float radius, float lineWidth)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        var pointCount = segments + 1; 
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0);
        }

        line.SetPositions(points);
    }
}

