using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float rotationAngle;
    [SerializeField] float speed;

    private Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        startingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion v = startingRotation;
        v.z += rotationAngle / 225 * Mathf.Sin(Time.time * speed);
        transform.rotation = v;
    }
}
