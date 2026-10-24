
using UnityEngine;

public class SnapColliderControl : MonoBehaviour
{
    public Collider pieceCollider;

    public void OnSnapped()
    {
        if (pieceCollider != null)
        {
            pieceCollider.enabled = false;
        }
    }

    public void OnUnsnapped()
    {
        if (pieceCollider != null)
        {
            pieceCollider.enabled = true;
        }
    }
}
