using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDispenser : MonoBehaviour
{
    public Food pancakePrefab;
    public Food milkshakePrefab;

    private Food dispensedFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dispensedFood == null) {
            dispenseFood();
        }
    }

    private void dispenseFood() {
        //Debug.Log("dispensing food");
        float selector = Random.Range(-1.0f, 1.0f);

        Food selectedPrefab = selector < 0.0f ? 
            pancakePrefab : milkshakePrefab;
        
        dispensedFood = Instantiate(selectedPrefab, transform.position, Quaternion.identity) as Food;
    }
}
