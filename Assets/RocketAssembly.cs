
using System.Collections;
using UnityEngine;
using TMPro;

public class RocketAssembly : MonoBehaviour
{
    public int requiredPieces = 8;
    public RocketLaunch rocketLaunch;
    
    private int attachedPieces = 1;
    private bool onLaunchPad = false;
    private bool launched = false;
    private Coroutine countdown;
    public TextMeshProUGUI countdownText;

    public void PieceAttached()
    {
        attachedPieces++;
        Debug.Log("Pieces attached: " + attachedPieces);
        CheckLaunch();
    }

    public void PieceRemoved()
    {
        attachedPieces = Mathf.Max(0, attachedPieces - 1);
        Debug.Log("Pieces attached: " + attachedPieces);
        CheckLaunch();
    }

    public void SetOnLaunchPad(bool onPad)
    {
        onLaunchPad = onPad;
        Debug.Log("On launch pad: " + onLaunchPad);
        CheckLaunch();
    }

    private void CheckLaunch()
    {
        bool ready = attachedPieces == requiredPieces
                     && onLaunchPad && !launched;

        if (ready && countdown == null)
        {
            countdown = StartCoroutine(LaunchCountdown());
        }
        else if (!ready && countdown != null)
        {
            StopCoroutine(countdown);
            countdown = null;
            countdownText.text = "Launch Cancelled";
        }
    }

    
private IEnumerator LaunchCountdown()
{
    countdownText.text = "Launching in 3...";
    yield return new WaitForSeconds(1);

    countdownText.text = "2...";
    yield return new WaitForSeconds(1);

    countdownText.text = "1...";
    yield return new WaitForSeconds(1);

    countdown = null;

    if (attachedPieces == requiredPieces &&
        onLaunchPad && !launched && rocketLaunch != null)
    {
        launched = true;
        countdownText.text = "LIFTOFF!";
        rocketLaunch.Launch();
    }
}

}
