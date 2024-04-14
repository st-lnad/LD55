using UnityEngine;

public class Glif : MonoBehaviour
{
    [SerializeField] private GameObject _pattern;
    [SerializeField] private GameObject _paint;

    private Material _patternMaterial;
    private Material _paintMaterial;

    private void Start()
    {
        _patternMaterial = _pattern.GetComponent<Renderer>().material;
        _paintMaterial = _paint.GetComponent<Renderer>().material;
    }

    [ContextMenu("Check glif quality")]
    private void Check()
    {
        //SaveTextureAsPNG((Texture2D)_paintMaterial.mainTexture, "C:\\Users\\Lev\\UnityProjects\\LD55\\Assets\\Glifs\\Sprites\\paint.png");
        GlifQualityChecker.CheckWithoutColor((Texture2D)_patternMaterial.mainTexture, (Texture2D)_paintMaterial.mainTexture);
    }

    //private void SaveTextureAsPNG(Texture2D _texture, string _fullPath)
    //{
    //    byte[] _bytes = _texture.EncodeToPNG();
    //    System.IO.File.WriteAllBytes(_fullPath, _bytes);
    //    Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + _fullPath);
    //}
}
