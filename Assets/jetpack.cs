using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jetpack : MonoBehaviour
{
    public float fuel = 5;
    private float cFuel;
    public bool ready;
    public Image Jetfuel;
        // Start is called before the first frame update
    void Start()
    {
        cFuel = fuel;
        Jetfuel.fillAmount = cFuel / fuel;
    }

    public void useFuel() {
        cFuel--;
        Jetfuel.fillAmount = cFuel / fuel;
        if (cFuel <= 0) {
            cFuel = fuel;
            ready = false;
            transform.SetParent(null);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
