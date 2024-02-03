using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float _karmaScore = 0f;
    public GameObject _emailPage;
    public string _ramuanHasil = "";
    public bool _completed = false;
    public string _ramuanYangDiminta;
    public string _Diminta;

    public GameObject _floatText;
    public TextMeshProUGUI _hasil;

    Image Window;
    Image _monitor;
    bool _openMail;
    float _hari;
    public float timer;
    bool reset;

    void Start()
    {
        _monitor = _emailPage.GetComponent<Image>();
        Window = _floatText.GetComponent<Image>(); 
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
        else if(_completed)
        {
            _hari++;
            OpenEmail();
        }

        // Kalau ramuan siap
        else if(_ramuanHasil != "")
        {
            timer += Time.deltaTime;
            if(timer <= 4f)
            {
                if(_ramuanHasil == _Diminta){
                _hasil.text = "Ramuan yang kamu buat benar";
                }
                else{
                _hasil.text = "Ramuan yang kamu buat salah, rek";
                }
                Vector3 _targetPos = new Vector3(-9.2f,-195.7f,0f);
                Window.rectTransform.anchoredPosition = Vector3.Lerp(Window.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
            }
            else if(timer > 4f && timer <=6f){
                Vector3 _targetPos = new Vector3(-9.2f,-254.85f,0f);
                Window.rectTransform.anchoredPosition = Vector3.Lerp(Window.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
            }else
            {
                _completed = true;
            }
        } 
    }


    public void OpenEmail()
    {
        _emailPage.SetActive(true);
        _openMail = true;
    }

}
