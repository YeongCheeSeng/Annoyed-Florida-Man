using UnityEngine;

public class LayerCollisionManager : MonoBehaviour
{
    //public int CurrentLayerMask;
    //public int LayerMaskToIgnore;

    //void Update()
    //{
    //    Physics2D.IgnoreLayerCollision(CurrentLayerMask, LayerMaskToIgnore);
    //}

    public int LayerMaskToIgnore;

    void Update()
    {
        int CurrentLayerMask = gameObject.layer;

        Physics2D.IgnoreLayerCollision(CurrentLayerMask, LayerMaskToIgnore);
    }
}
