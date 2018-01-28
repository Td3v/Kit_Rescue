using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBallController : MonoBehaviour {

    private Rigidbody2D rb;
    float xmin = -5f;
    float xmax = 5f;
    float padding = .5f;
    public float speed = 5.0f;
    float zdistance;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 dragPos;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float zdistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zdistance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
    // Update is called once per frame
    void Update()
    {
        //float mousePos = Input.mousePosition.x;
        //Vector3 foxPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos, transform.position.y, transform.position.z));
        //transform.position = new Vector3(foxPos.x, transform.position.y, transform.position.z);
        //float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        //transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    z += Time.deltaTime * 100000;
        //    transform.rotation = Quaternion.Euler(0, 0, -z);
        //}
    }
    private void OnMouseDown()
    {
        startPos = Input.mousePosition;
        //print(startPos);
    }
   
    private void OnMouseDrag()
    {
        dragPos = Input.mousePosition;
        Vector3 foxPos = Camera.main.ScreenToWorldPoint(new Vector3(dragPos.x, dragPos.y, transform.position.z));
        transform.position = new Vector3(foxPos.x, foxPos.y, transform.position.z);
        float newY = Mathf.Clamp(transform.position.y, -10f, -3f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
    private void OnMouseUp()
    {
        endPos = Input.mousePosition;
        direction = startPos - endPos;
        rb.AddForce(direction * 5);
    }
}
