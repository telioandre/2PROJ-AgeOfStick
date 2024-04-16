using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Casern : MonoBehaviour
{
    [SerializeField]
    public GameObject objectToInstantiate;
    public GameObject objectToInstantiate2;
    public GameObject objectToInstantiate3;
    public GameObject objectToInstantiate4;
    private float cooldown = 1f;
    private float lastPressTimeE;
    private float lastPressTimeQ;
    protected int numberOfTroop1 = 0;
    protected int numberOfTroop2 = 0;
    public List<GameObject> troops = new List<GameObject>();

    void Start()
    {
        lastPressTimeE = -cooldown;
        lastPressTimeQ = -cooldown;
    }

    public void CreateTroop1()
    {
        if(Time.time - lastPressTimeE > cooldown)
        {
            if (numberOfTroop1 < 10)
            {
                lastPressTimeE = Time.time;
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    troops.Add(newObject);
                    for(int i=0; i<troops.Count; i++)
                    {
                        Debug.Log(troops[i] + " la");
                    }
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
        }
    }

    public void CreateTroop2()
    {
        if (Time.time - lastPressTimeE > cooldown)
        {
            if (numberOfTroop1 < 10)
            {
                lastPressTimeE = Time.time;
                GameObject newObject = Instantiate(objectToInstantiate2, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    troops.Add(newObject);
                    /*for (int i = 0; i < troops.Count; i++)
                    {
                        Debug.Log(troops[i] + " la");
                    }*/
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
        }
    }

    public void CreateTroop3()
    {
        if (Time.time - lastPressTimeE > cooldown)
        {
            if (numberOfTroop1 < 10)
            {
                lastPressTimeE = Time.time;
                GameObject newObject = Instantiate(objectToInstantiate3, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    troops.Add(newObject);
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
        }
    }

    public void CreateTroop4()
    {
        if (Time.time - lastPressTimeE > cooldown)
        {
            if (numberOfTroop1 < 10)
            {
                lastPressTimeE = Time.time;
                GameObject newObject = Instantiate(objectToInstantiate4, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    troops.Add(newObject);
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
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastPressTimeE > cooldown)
        {
            if(numberOfTroop1 < 10)
            {
                lastPressTimeE = Time.time;
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
            else
            {
                Debug.Log("Maximum troop reached");
            }
        }
    /*if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastPressTimeQ > cooldown)
        {
            if (numberOfTroop2 < 10)
            {
                lastPressTimeQ = Time.time;
                Debug.Log("A key pressed");
                GameObject newObject = Instantiate(objectToInstantiate5, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    Movement script = newObject.GetComponent<Movement>();
                    if (script != null)
                    {
                        numberOfTroop2 += 1;
                        Debug.Log(numberOfTroop2);
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
            else
            {
                Debug.Log("Maximum troop reached");
            }
        }*/
    }

    public void DestroyTroop1()
    {
        //numberOfTroop1 -= 1;
        Debug.Log("troop ID 1 : " + numberOfTroop1);
    }
    public void DestroyTroop2()
    {
        //numberOfTroop2 -= 1;
        Debug.Log("troop ID 2 : " + numberOfTroop2);
    }
}

