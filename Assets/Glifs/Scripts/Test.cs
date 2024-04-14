using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Material _testPattern;
    [SerializeField] private Glif _testGlif;

    [ContextMenu("Поменять паттерн")]
    private void SwitchPatter()
    {
        _testGlif.SetPattern(_testPattern);
    }
}
