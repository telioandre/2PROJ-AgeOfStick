using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casern : MonoBehaviour
{
    [SerializeField]
    public GameObject objectToInstantiate;
    public GameObject objectToInstantiate2;
    private float lastPressTime;
    private float cooldown = 1f;
    private int numberOfTroop1 = 0;
    private int numberOfTroop2 = 0;

    void Start()
    {
        lastPressTime = -cooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastPressTime > cooldown)
        {
            lastPressTime = Time.time;
            Debug.Log("E key pressed");
            GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            if (newObject != null)
            {
                Movement script = newObject.GetComponent<Movement>();
                if (script != null)
                {
                    numberOfTroop1 += 1;
                    Debug.Log(numberOfTroop1);
                    script.setPlayer(1);
                }
                else
                {
                    Debug.LogError("Movement script not found on the instantiated object");
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate objectToInstantiate");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastPressTime > cooldown)
        {
            lastPressTime = Time.time;
            Debug.Log("A key pressed");
            GameObject newObject = Instantiate(objectToInstantiate2, transform.position, Quaternion.identity);
            if (newObject != null)
            {
                Movement script = newObject.GetComponent<Movement>();
                if (script != null)
                {
                    numberOfTroop2 += 1;
                    Debug.Log(numberOfTroop1);
                    script.setPlayer(2);
                }
                else
                {
                    Debug.LogError("Movement script not found on the instantiated object");
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate objectToInstantiate");
            }
        }
    }
}