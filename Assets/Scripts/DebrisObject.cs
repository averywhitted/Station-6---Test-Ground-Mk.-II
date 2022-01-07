using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class DebrisObject : MonoBehaviour
{
    public Rigidbody rb;
    public float startForceRange;
    public float posRange;
    public float scaleRange;

    public Vector3 startHeading;

    public Vector3 startRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        StartObject();
    }

    public void StartObject()
    {
        //Rotation
        rb.AddRelativeTorque(new Vector3(Random.Range(-startForceRange, startForceRange), Random.Range(-startForceRange, startForceRange), Random.Range(-startForceRange, startForceRange)));
        rb.AddForce(Random.Range(-startForceRange, startForceRange), Random.Range(-startForceRange, startForceRange), Random.Range(-startForceRange, startForceRange), ForceMode.Impulse);
        
        //Heading


        //Position
        transform.position = new Vector3(Random.Range(-posRange, posRange), Random.Range(-posRange, posRange), Random.Range(-posRange, posRange));

        //Scale
        float randomNumber = Random.Range(0.25f, scaleRange);
        Vector3 randomScale = new Vector3(randomNumber, randomNumber, randomNumber);
        transform.localScale += randomScale;
    }
}
