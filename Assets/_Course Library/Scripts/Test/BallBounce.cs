using BNG;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using HenryLab;

[RequireComponent(typeof(AudioSource))]
public class BallBounce : MonoBehaviour, IGrabbableEntity
{
    [ExcludeFromCodeCoverage]
    public void OnReleased()
    {
    }
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
    [ExcludeFromCodeCoverage] public Transform Destination => null;

    [ExcludeFromCodeCoverage] public string Name => Str.Grabbable;

    public Transform Destination => throw new System.NotImplementedException();

    [ExcludeFromCodeCoverage]
    public void OnGrabbed()
    {
    }

    public AudioClip collisionSound; // Sound clip for ball collision

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play the collision sound if a collision occurs
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    public void OnReleased()
    {
        throw new System.NotImplementedException();
    }
}
