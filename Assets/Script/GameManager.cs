using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float _karmaScore = 0f;
    public GameObject _emailPage;
    Image _monitor;
    public bool _completed = false;
    bool _openMail;
    float _hari;
    public string _ramuanHasil;

    void Start()
    {
        _monitor = _emailPage.GetComponent<Image>();
        OpenEmail();
    }

    void Update()
    {
        // Kalau buka mail
        if(_openMail)
        {
            Vector3 _targetPos = new Vector3(0f,0f,0f);
            _monitor.rectTransform.anchoredPosition = Vector3.Lerp(_monitor.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
            if(Vector3.Distance(_targetPos, _monitor.rectTransform.anchoredPosition) <= 0.1f){
                _openMail = false;
            }
        }
        if(_completed)
        {
            _hari++;
            OpenEmail();
        }
    }


    public void OpenEmail()
    {
        _emailPage.SetActive(true);
        _openMail = true;
    }
}
