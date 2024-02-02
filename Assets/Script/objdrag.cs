using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class objdrag : MonoBehaviour
{
    private Outline outline;
    public Vector2 posisiawal;
    public bool isdilepas;
    public GameObject objek;
    public int stok = 5;
    public bool pause = true;
    void Start()
    {
        posisiawal = transform.position;
        outline = GetComponent<Outline>();
        if (outline == null){
            outline = gameObject.AddComponent<Outline>();
        }
        outline.enabled = false;
    }
    private void OnMouseDrag(){
        if (stok > 0 && !pause){
        Vector2 posisi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isdilepas = false;
        objek.SetActive(true);
        objek.transform.position = posisi;
        }else {
            Debug.Log("Habis ngab");
        }
    }
    private void OnMouseUp(){
        isdilepas = true;
        Invoke("off", 0.02f);
    }
    private void off(){
        objek.SetActive(false);
    }
    private void OnMouseOver() {
        outline.enabled = true;
    }
    private void OnMouseExit() {
        outline.enabled = false;
    }
}
