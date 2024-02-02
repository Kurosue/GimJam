using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float _karmaScore = 0f;
    public GameObject _emailPage;
    Image _monitor;
    // Start is called before the first frame update


    bool _openMail;
    void Start()
    {
        _monitor = _emailPage.GetComponent<Image>();
        OpenEmail();
    }

    // Update is called once per frame
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
    }

    public void OpenEmail()
    {
        _emailPage.SetActive(true);
        _openMail = true;
    }
}
