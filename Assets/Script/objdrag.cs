using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objdrag : MonoBehaviour
{
    public Vector2 posisiawal;
    public bool isdilepas;

    public GameObject objek;
    void Start()
    {
        posisiawal = transform.position;
    }
    void Update() 
    {
    }
    private void OnMouseDrag(){
        Vector2 posisi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isdilepas = false;
        objek.SetActive(true);
        objek.transform.position = posisi;
    }
    public void OnMouseUp(){
        isdilepas = true;
        Invoke("off", 0.02f);
    }
    public void OnMouseDown() {
        isdilepas = false;
    }
    private void off(){
        objek.SetActive(false);
    }
}
