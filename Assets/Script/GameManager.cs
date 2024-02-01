using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _emailInbox;
    public float _karmaScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _emailInbox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
