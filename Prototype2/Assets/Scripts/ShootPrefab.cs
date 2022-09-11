using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//attach this to player
public class ShootPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToShoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);

        }
        
    }
}
