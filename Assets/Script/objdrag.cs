using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objdrag : MonoBehaviour
{
    public Vector2 posisiawal;
    public bool isdilepas;
    public GameObject objek;
    public int stok = 5;
    void Start()
    {
        posisiawal = transform.position;
    }
    private void OnMouseDrag(){
        if (stok > 0){
        Vector2 posisi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isdilepas = false;
        objek.SetActive(true);
        objek.transform.position = posisi;
        }else {
            Debug.Log("Habis ngab");
        }
    }
    public void OnMouseUp(){
        isdilepas = true;
        Invoke("off", 0.02f);
    }
    private void off(){
        objek.SetActive(false);
    }
}
