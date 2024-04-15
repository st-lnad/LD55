using UnityEngine;

public class Paint : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Material _material;
    [SerializeField] private Collider _collider;
    [SerializeField] private Color _color;
    [SerializeField] private int _brushSize = 8;

    private int _textureSize = 512;
    private int _oldRayX, _oldRayY;
    private bool _paintModeOn = false;
    


    private void Awake()
    {
        _texture = GenerateSquareTexture(_textureSize);
        _texture.wrapMode = TextureWrapMode.Repeat;
        _texture.filterMode = FilterMode.Point;
        _texture.Apply();
        _material.mainTexture = _texture;
        _material = GetComponent<Renderer>().material;
        _material.mainTexture = _texture;
    }

    private void Update()
    {
        if (!_paintModeOn)
            return;

        _brushSize += (int)Input.mouseScrollDelta.y;

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_collider.Raycast(ray, out RaycastHit hit, 100f))
            {
                int rayX = (int)(hit.textureCoord.x * _textureSize);
                int rayY = (int)(hit.textureCoord.y * _textureSize);

                if (_oldRayX != rayX || _oldRayY != rayY)
                {
                    DrawCircle(rayX, rayY);
                    _oldRayX = rayX;
                    _oldRayY = rayY;
                }
                _texture.Apply();
            }
        }
    }

    public void AllowPainting()
    {
        _paintModeOn = true;
    }

    public void ForbidPainting()
    {
        _paintModeOn = false;
    }

    private Texture2D GenerateSquareTexture(int size)
    {
        Texture2D res = new Texture2D(size, size);
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                res.SetPixel(x, y, new Color(0, 0, 0, 0));
            }
        }
        return res;
    }

    private void DrawCircle(int rayX, int rayY)
    {
        int halfBrushSize = _brushSize / 2;
        for (int y = 0; y < _brushSize; y++)
        {
            for (int x = 0; x < _brushSize; x++)
            {

                float x2 = Mathf.Pow(x - halfBrushSize, 2);
                float y2 = Mathf.Pow(y - halfBrushSize, 2);
                float r2 = Mathf.Pow(halfBrushSize - 0.5f, 2);

                if (x2 + y2 < r2)
                {
                    int pixelX = rayX + x - halfBrushSize;
                    int pixelY = rayY + y - halfBrushSize;

                    if (pixelX >= 0 && pixelX < _textureSize && pixelY >= 0 && pixelY < _textureSize)
                    {
                        Color oldColor = _texture.GetPixel(pixelX, pixelY);
                        Color resultColor = Color.Lerp(oldColor, _color, _color.a);
                        _texture.SetPixel(pixelX, pixelY, resultColor);
                    }

                }
            }
        }
    }

}
