using BNG;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using HenryLab;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class LaunchProjectile : MonoBehaviour, ITriggerableEntity, IGrabbableEntity
{
    [ExcludeFromCodeCoverage] public float TriggeringTime => 1.5f;
    [ExcludeFromCodeCoverage] public string Name => Str.Gun;
    [ExcludeFromCodeCoverage] public Transform Destination => null;

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

    [ExcludeFromCodeCoverage] public void Triggerring() { }

    [ExcludeFromCodeCoverage]
    public void Triggerred()
    {
        Fire();
    }

    [ExcludeFromCodeCoverage] public void OnGrabbed() { }

    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 1.0f;

    public void Fire()
    {
        GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);

        if(newObject.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);
    }

    public void OnReleased()
    {
        throw new System.NotImplementedException();
    }
}
