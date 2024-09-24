using UnityEngine;

public class MontyHallPedestal : MonoBehaviour
{

    [HideInInspector]
    public Material material;

    [HideInInspector]
    public enum State { Idle, Activated, Revealed }

    [HideInInspector]
    public State state;


    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                material.color = Color.white; break;
            case State.Activated:
                material.color = Color.magenta; break;
            case State.Revealed:
                material.color = Color.cyan; break;
            default:
                material.color = Color.white; break;
        }
    }

}
