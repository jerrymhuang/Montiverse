using UnityEngine;

public class MontyHallPortal : MonoBehaviour
{

    [SerializeField]
    GameObject controller;

    MontyHallPedestal[] pedestals;


    void Awake()
    {
        pedestals = FindObjectsByType<MontyHallPedestal>(FindObjectsSortMode.InstanceID);
        for (int i = 0; i < pedestals.Length; i++) Debug.Log(i + pedestals[i].name);
    }



    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
