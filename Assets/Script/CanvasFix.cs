using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFix : MonoBehaviour
{
    public GameObject Target;

    private bool _isFliped;

    // Start is called before the first frame update
    void Start()
    {
        _isFliped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return;

        Vector3 targetScale = Target.transform.localScale;
        Vector3 currentScale = transform.localScale;

        if (targetScale.x == 1 && _isFliped == true)
        {
            currentScale.x = -currentScale.x;
            transform.localScale = currentScale;
            _isFliped = false;
        }

        if (targetScale.x == -1 && _isFliped == false)
        {
            currentScale.x = -currentScale.x;
            transform.localScale = currentScale;
            _isFliped = true;
        }
    }
}
