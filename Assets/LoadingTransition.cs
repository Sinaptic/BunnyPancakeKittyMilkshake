using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Application.LoadLevel("MainScene");
        }
    }

    IEnumerator waitToLoad() {
        
        yield return new WaitForSeconds(2.0f);

        Application.LoadLevel("MainScene");
    }
}
