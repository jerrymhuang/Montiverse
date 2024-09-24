using UnityEngine;

public class Spinner : MonoBehaviour
{



    void Start()
    {
        float angle = Random.Range(-45f, 45f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 15f * Time.deltaTime);
    }
}
