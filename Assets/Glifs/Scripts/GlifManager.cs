using System.Collections.Generic;
using UnityEngine;

public class GlifManager : MonoBehaviour
{
    [SerializeField] private List<Glif> _glifs;
    [SerializeField] private List<Material> _glifPatterns;
    private bool _initialized = false;

    private void Start()
    {
        if (!_initialized)
        {
            Debug.Log("Initialize");
            foreach (var glif in _glifs)
            {
                glif.gameObject.SetActive(true);
                glif.SetPattern(_glifPatterns[Random.Range(0, _glifPatterns.Count)]);
            }
            Generate();
            _initialized = true;
        }
    }

    [ContextMenu("ѕерегенерить")]
    public void Generate()
    {
        int spawned = 0;
        for (int i = 0; i < _glifs.Count; i++)
        {
            var glif = _glifs[i];
            glif.gameObject.SetActive(true);
            if (Random.Range(0f, 1f) > 0.2f && !(i == _glifs.Count-1 && spawned == 0))
                glif.gameObject.SetActive(false);
            else
            {
                glif.SetPattern(_glifPatterns[Random.Range(0, _glifPatterns.Count)]);
                spawned++;
            }
        }
    }

    [ContextMenu("ќцениь результат")]
    public void EvaluateResult()
    {
        float mean = 0f;
        int activeGlifCounter = 0;
        foreach (var glif in _glifs)
        { 
            if (glif.gameObject.activeInHierarchy)
            {
                mean += glif.CheckQuality();
                activeGlifCounter++;
            }
        }
        mean /= activeGlifCounter;
        Debug.Log($"ќценка по всем глифам - {mean}. „итаешь - мудак или Ћев)");
        //return mean;
    }
}
