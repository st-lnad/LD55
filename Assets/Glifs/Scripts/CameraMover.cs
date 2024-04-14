using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve _speed;
    [SerializeField, Min(0.01f)] private float _transitionTime;

    private Vector3 previousPosition;
    private Vector3 glifPosition;
    public void MoveToGlif(Glif glif)
    {
        previousPosition = transform.position;
        glifPosition = glif.transform.position;
        glifPosition.z = previousPosition.z;
        StartCoroutine(nameof(Move));
        
    }

    private IEnumerator Move()
    {
        float t = 0f;
        var delay = new WaitForEndOfFrame();
        while (t <= 1f)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(previousPosition, glifPosition, t);
            yield return delay;
        }
    }
}
