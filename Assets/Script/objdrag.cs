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
    public PauseMenu _paused;
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
        if(!_paused._pause)
        {
        Vector2 posisi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isdilepas = false;
        objek.SetActive(true);
        objek.transform.position = posisi;
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
