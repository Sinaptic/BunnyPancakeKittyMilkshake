using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatText : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return fadeUp();
    }

    IEnumerator fadeUp() {


        float distance = 1.2f;
        float speed = 1.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, speed, 0.0f);
        yield return new WaitForSeconds(distance / speed);

        Destroy(this.gameObject);
    }
}
