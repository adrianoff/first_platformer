using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = this.transform.position.z;
        this.transform.position = Vector3.Lerp(transform.position, position, this.speed * Time.deltaTime);
    }
}
