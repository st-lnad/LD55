using UnityEngine;

public class Glif : MonoBehaviour
{
    [SerializeField] private GameObject _patternObject;
    [SerializeField] private GameObject _paintObject;

    private Material _patternMaterial;
    private Material _paintMaterial;

    [SerializeField] private Vector2 _grade1Coefs; 
    [SerializeField] private Vector2 _grade2Coefs; 
    [SerializeField] private Vector2 _grade3Coefs;
    [SerializeField] private Vector2 _loseCoefs;

    private void Start()
    {
        _patternMaterial = _patternObject.GetComponent<Renderer>().material;
        _paintMaterial = _paintObject.GetComponent<Renderer>().material;
    }

    public void SetPattern(Material pattern)
    {
        _patternMaterial.CopyPropertiesFromMaterial(pattern);
        _paintObject.GetComponent<Paint>().ClearCanvas();
    }


    [ContextMenu("Check glif quality")]
    public float CheckQuality()
    {
        Vector2 res = GlifQualityChecker.CheckWithoutColor((Texture2D)_patternMaterial.mainTexture, (Texture2D)_paintMaterial.mainTexture);
        if (res.x < _loseCoefs.x || res.y < _loseCoefs.y) return 0f;
        if (res.magnitude >= _grade1Coefs.magnitude) return 1f;
        if (res.magnitude >= _grade2Coefs.magnitude) return 0.66f;
        if (res.magnitude >= _grade3Coefs.magnitude) return 0.33f;
        Debug.Log("Коэффициенты говно");
        return 0.2f;
    }

    

}
