using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float startX;
    private bool pressed = false;
    private float swipeAmount = 100.0f;
    private bool feeding = false;
    private bool dispensing = false;

    public EatText yummyText;
    public EatText yuckyText;

    // Start is called before the first frame update
    void Start()
    {
        dispensing = true;
        StartCoroutine(dispense());
    }

    // Update is called once per frame
    void Update()
    {
        if(dispensing || feeding) { 
            return;
        }

        if(!pressed && Input.GetMouseButtonDown(0)) {
            startX = Input.mousePosition.x;
            pressed = true;
        } else if(pressed) {
            float delta = Input.mousePosition.x - startX;
            
            if(delta < -swipeAmount) {
                startX = 0.0f;
                StartCoroutine(feedLeft());
            } else if(delta > swipeAmount) {
                startX = 0.0f;
                StartCoroutine(feedRight());
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            pressed = false;
        }
    }

    IEnumerator dispense() {
        //Debug.Log("dispensing");

        dispensing = true;

        float distance = 3.0f;
        float speed = 5.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -speed, 0.0f);
        yield return new WaitForSeconds(distance / speed);

        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        dispensing = false;
        yield return null;
    }

    IEnumerator feedLeft() {
        //Debug.Log("Feed left");
        feeding = true;

        float distance = 2.0f;
        float speed = 4.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0.0f, 0.0f);
        yield return new WaitForSeconds(distance / speed);

        //Debug.Log("eating");
        Destroy(transform.gameObject);

        if(transform.name.StartsWith("Pancake")) {
            // create yummy text
            Instantiate(yummyText, transform.position + new Vector3(-1.5f, 1.6f, 0.0f), Quaternion.identity);
        } else {
            // create yucky text
            Instantiate(yuckyText, transform.position + new Vector3(-1.5f, 1.6f, 0.0f), Quaternion.identity);
        }

        yield return new WaitForSeconds(1.0f);

        yield return null;
    }

    IEnumerator feedRight() {
        //Debug.Log("Feed right");
        feeding = true;

        float distance = 2.0f;
        float speed = 4.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0.0f, 0.0f);
        yield return new WaitForSeconds(distance / speed);

        //Debug.Log("eating");
        Destroy(transform.gameObject);

        if(transform.name.StartsWith("Pancake")) {
            // create yucky text
            Instantiate(yuckyText, transform.position + new Vector3(0.3f, 1.6f, 0.0f), Quaternion.identity);
        } else {
            // create yummy text
            Instantiate(yummyText, transform.position + new Vector3(0.3f, 1.6f, 0.0f), Quaternion.identity);
        }

        yield return new WaitForSeconds(1.0f);

        yield return null;
    }
}
