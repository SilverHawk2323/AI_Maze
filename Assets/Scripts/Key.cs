using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    float _angle = 0f;
    public float rotationSpeed = 40f;
    public float frequency = 1f;
    public float magnitude = 1f;
    public MoveDoor door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);

        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        float yOffset = Mathf.Sin(Time.time * frequency) * magnitude;

        transform.position += new Vector3(0, yOffset, 0) * Time.deltaTime;
    }

    public void OpenDoor()
    {
        door.unlockDoor = true;
        Destroy(gameObject);
    }
}
