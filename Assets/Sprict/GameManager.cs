using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _exitButton;
    // Start is called before the first frame update
    void Start()
    {
        _exitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            _exitButton.SetActive(true);
        }
    }
}
