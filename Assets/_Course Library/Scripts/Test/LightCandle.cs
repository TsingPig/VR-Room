using BNG;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using HenryLab;

public class LightCandle : MonoBehaviour, IGrabbableEntity
{
    [ExcludeFromCodeCoverage]
    public Grabbable Grabbable
    {
        get
        {
            var g = GetComponent<Grabbable>();
            if (g) return g;
            return gameObject.AddComponent<Grabbable>();
        }
    }
    [ExcludeFromCodeCoverage] public string Name => Str.Grabbable;

    [ExcludeFromCodeCoverage] public Transform Destination => null;


    [ExcludeFromCodeCoverage]
    public void OnGrabbed()
    {
    }

    [ExcludeFromCodeCoverage]
    public void OnReleased()
    {
    }
    public ParticleSystem flames;
    private Rigidbody rigidbody;
    public float velocityThreshold = 0.5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (rigidbody.velocity.magnitude >= velocityThreshold)
        {
            flames.Stop();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flames.Play();
        }
    }

}
