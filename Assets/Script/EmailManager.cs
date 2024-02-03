using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class InboxManager : MonoBehaviour
{
    public Image _select;
    public List<float> _Yaxis;
    public int _email = 0;
    public GameManager _completed;
    public trigger _trigger;

    public List<EmailMessage> originalList;
    private int numberOfItemsToSelect = 5;
    private List<EmailMessage> _selectedEmail;


    public List<TextMeshProUGUI> _listSubjectText;
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI FromText;
    public GameObject _accButton;
    public GameObject _closeButton;
    public GameObject _decButton;

    Image _monitor;
    bool _acc = false;
    bool _close = false;

    private void Start()
    {
        _selectedEmail = SelectRandomItems(originalList, numberOfItemsToSelect);
        _monitor = GetComponent<Image>();
        ShowRandomMessage();
        _closeButton.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            _listSubjectText[i].text = _selectedEmail[i].subject;
        }
    }


    private void Update()
    {
        Vector3 _targetPos = new Vector3(-251.5932f, _Yaxis[_email], 0f);
        // Pindah Email
        if(Vector3.Distance(_targetPos, _select.rectTransform.anchoredPosition) > 0.0001f){
            _select.rectTransform.anchoredPosition = Vector3.Lerp(_select.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
        }

        // Kalau Email diterima
        if(_acc){
            _targetPos = new Vector3(0f,-500f,0f);
            _monitor.rectTransform.anchoredPosition = Vector3.Lerp(_monitor.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
            if(Vector3.Distance(_targetPos, _monitor.rectTransform.anchoredPosition) <= 5f){
                _acc = false;
                gameObject.SetActive(false);
            }
        }

        // Aktif jika tombol close ditekam
        if(_close){
            _targetPos = new Vector3(0f,-500f,0f);
            _monitor.rectTransform.anchoredPosition = Vector3.Lerp(_monitor.rectTransform.anchoredPosition, _targetPos, 7f * Time.deltaTime);
            if(Vector3.Distance(_targetPos, _monitor.rectTransform.anchoredPosition) <= 5f){
                _close = false;
                gameObject.SetActive(false);
            }
        }

        // Kalau masak selesai, tombol terima dan tolak dikembalikan
        if(_completed._completed)
        {
            _closeButton.SetActive(false);
            _accButton.SetActive(true);
            _decButton.SetActive(true);
            DeclineEmail();
            ResetGame();
            Debug.Log(0);
        }
    }


    public void AcceptEmail()
    {
        _acc = true;
        _closeButton.SetActive(true);
        _accButton.SetActive(false);
        _decButton.SetActive(false);
        ResetGame();
        
    }

    public void DeclineEmail()
    {
        if(_email < 4f)
        {    
            _email++;
            ShowRandomMessage();
        }
    }

    public void CloseButton()
    {
        _close = true;
    }

    void ShowRandomMessage()
    {
        EmailMessage currentMessage = _selectedEmail[_email];

        // subjectText.text = currentMessage.subject;
        FromText.text = "From : " + currentMessage.From;
        bodyText.text = currentMessage.body;
    }

    List<T> SelectRandomItems<T>(List<T> originalList, int numberOfItemsToSelect)
    {
        List<T> selectedItems = new List<T>();

        if (numberOfItemsToSelect >= originalList.Count)
        {
            // If the requested number is greater or equal to the original list size,
            // simply return a copy of the original list.
            return new List<T>(originalList);
        }

        // Generate a list of unique random indices
        List<int> randomIndices = GenerateRandomIndices(originalList.Count, numberOfItemsToSelect);

        // Select items from the original list based on random indices
        foreach (int index in randomIndices)
        {
            selectedItems.Add(originalList[index]);
        }

        foreach (T objek in selectedItems)
        {
            originalList.Remove(objek);
        }

        return selectedItems;
    }

    List<int> GenerateRandomIndices(int listSize, int numberOfItemsToSelect)
    {
        List<int> indices = new List<int>();

        while (indices.Count < numberOfItemsToSelect)
        {
            int randomIndex = Random.Range(0, listSize);

            // Ensure the index is unique
            if (!indices.Contains(randomIndex))
            {
                indices.Add(randomIndex);
            }
        }

        return indices;
    }

    public void ResetGame()
    {
        _trigger.jumlahbroto = 0;
        _trigger.jumlahkencur = 0;
        _trigger.jumlahsirih = 0;
        _trigger.jumlahtemu = 0;
        _trigger.stop = true;
        _completed._completed = false;
        _completed._ramuanHasil = "";
        _completed.timer = 0f;
    }

}
