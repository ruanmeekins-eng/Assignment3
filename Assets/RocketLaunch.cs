
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public Rigidbody rocketRigidbody;
    public float launchForce = 20f;
    public float flightDuration = 5f;

    public ParticleSystem rocketFlames;
    public AudioSource rocketSound;

    private bool launched = false;
    private float launchTime;

    public void Launch()
    {
        if (launched || rocketRigidbody == null)
            return;

        launched = true;
        launchTime = Time.time;

        rocketRigidbody.isKinematic = false;
        rocketRigidbody.useGravity = false;

        rocketRigidbody.linearVelocity = Vector3.zero;
        rocketRigidbody.angularVelocity = Vector3.zero;

        // Start exhaust flames
        if (rocketFlames != null)
            rocketFlames.Play();

        // Start engine sound
        if (rocketSound != null)
            rocketSound.Play();

        Debug.Log("Rocket launching!");
    }

    void FixedUpdate()
    {
        if (!launched)
            return;

        if (Time.time - launchTime < flightDuration)
        {
            rocketRigidbody.AddForce(
                Vector3.up * launchForce,
                ForceMode.Acceleration
            );
        }
        else
        {
            launched = false;

            // Stop exhaust flames
            if (rocketFlames != null)
                rocketFlames.Stop();

            // Stop engine sound
            if (rocketSound != null)
                rocketSound.Stop();
        }
    }
}
