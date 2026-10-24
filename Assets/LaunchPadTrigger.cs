
using UnityEngine;

public class LaunchPadTrigger : MonoBehaviour
{
    public RocketAssembly rocketAssembly;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            rocketAssembly.SetOnLaunchPad(true);
            Debug.Log("Rocket placed on launch pad!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            rocketAssembly.SetOnLaunchPad(false);
            Debug.Log("Rocket removed from launch pad!");
        }
    }
}
