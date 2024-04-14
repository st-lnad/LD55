using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnESC : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseUI.SetActive(!_pauseUI.activeInHierarchy);
        }
    }
}
