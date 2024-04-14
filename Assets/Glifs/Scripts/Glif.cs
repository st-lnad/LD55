using UnityEngine;

public class Glif : MonoBehaviour
{
    [SerializeField] private GameObject _patternObject;
    [SerializeField] private GameObject _paintObject;

    private Material _patternMaterial;
    private Material _paintMaterial;

    private void Start()
    {
        _patternMaterial = _patternObject.GetComponent<Renderer>().material;
        _paintMaterial = _paintObject.GetComponent<Renderer>().material;
    }

    public void SetPattern(Material pattern)
    {
        _patternMaterial.CopyPropertiesFromMaterial(pattern);
    }


    [ContextMenu("Check glif quality")]
    private void CheckQuality()
    {
        GlifQualityChecker.CheckWithoutColor((Texture2D)_patternMaterial.mainTexture, (Texture2D)_paintMaterial.mainTexture);
    }

    

}
