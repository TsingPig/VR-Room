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
            if(g) return g;
            return gameObject.AddComponent<Grabbable>();
        }
    }
    [ExcludeFromCodeCoverage] public string Name => Str.Grabbable;

<<<<<<< Updated upstream
    [ExcludeFromCodeCoverage] public Transform Destination => null;
=======
    public Transform Destination => throw new System.NotImplementedException();
>>>>>>> Stashed changes

    [ExcludeFromCodeCoverage]
    public void OnGrabbed()
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
        if(rigidbody.velocity.magnitude >= velocityThreshold)
        {
            flames.Stop();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            flames.Play();
        }
    }
<<<<<<< Updated upstream
    [ExcludeFromCodeCoverage]
    public void OnReleased()
    {
=======

    public void OnReleased()
    {
        throw new System.NotImplementedException();
>>>>>>> Stashed changes
    }
}
