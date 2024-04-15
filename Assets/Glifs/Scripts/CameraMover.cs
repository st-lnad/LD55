using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve _speed;
    [SerializeField, Min(0.01f)] private float _transitionTime;
    [SerializeField] float _normalSize = 5.4f;
    [SerializeField] float _scopeSize = 2f;
    [SerializeField] private Glif _targetGlif;

    private Camera _camera;
    private Vector3 previousPosition;
    private Vector3 glifPosition;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    [ContextMenu("Zoom")]
    public void MoveToGlif()
    {
        Glif glif = _targetGlif;
        _camera.enabled = true;
        previousPosition = transform.position;
        glifPosition = glif.transform.position;
        glifPosition.z = previousPosition.z;
        StartCoroutine(nameof(Move));
    }

    public void ResetPosition()
    {

    }

    private IEnumerator Move()
    {
        float t = 0f;
        var delay = new WaitForEndOfFrame();
        while (t <= 1f)
        {
            t += Time.deltaTime;
            _camera.orthographicSize = Mathf.Lerp(_normalSize, _scopeSize, t);
            transform.position = Vector3.Lerp(previousPosition, glifPosition, t);
            yield return delay;
        }
    }
}
