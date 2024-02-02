using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class trigger : MonoBehaviour
{
    private Outline outline;
    public bool temulawak, kencur, brotowali, sirih, stop;
    public int jumlahsirih, jumlahbroto, jumlahtemu, jumlahkencur;
    objdrag broto, temu, siri, kencu;
    public GameObject objekbroto, objektemu, objekkencur, objeksirih;
    public int _total;
    public GameManager _ramuan;
    void Awake() {
        broto = objekbroto.GetComponent<objdrag>();
        kencu = objekkencur.GetComponent<objdrag>();
        temu = objektemu.GetComponent<objdrag>();
        siri = objeksirih.GetComponent<objdrag>();
        outline = GetComponent<Outline>();
    }
    void Start(){
        if (outline == null){
            outline = gameObject.AddComponent<Outline>();
        }
        outline.enabled = false;
}
    void FixedUpdate(){
        if (brotowali && broto.isdilepas){
            jumlahbroto += 1;
        }else if (kencur && kencu.isdilepas){
            jumlahkencur += 1;
        }else if (temulawak && temu.isdilepas){
            jumlahtemu += 1;
        }else if (sirih && siri.isdilepas){
            jumlahsirih += 1;
        }
        _total = jumlahbroto + jumlahkencur + jumlahsirih + jumlahtemu;
        if(_total == 4)
        {
            GetPotion();
            stop = false;
        }
    }
    void OnTriggerStay2D(Collider2D collide) {
        if (collide.CompareTag("brotowali")){
            brotowali = true;
        }else if (collide.CompareTag("kencur")){
            kencur = true;
        }else if (collide.CompareTag("temulawak")){
             temulawak = true;
        }else if (collide.CompareTag("sirih")){
            sirih = true;
        }outline.enabled = true;
    }
    void OnTriggerExit2D(Collider2D collide){
        if (collide.CompareTag("brotowali")){ 
            brotowali = false;
        }else if(collide.CompareTag("temulawak")){
            temulawak = false;
        }else if(collide.CompareTag("sirih")){
            sirih = false;
        }else if(collide.CompareTag("kencur")){
            kencur = false;
        }outline.enabled = false;
    }

    void GetPotion()
    {
        if(jumlahkencur == 1 && jumlahtemu == 2 && jumlahsirih == 1){
            _ramuan._ramuanHasil = "Ramuan Pelet";
        }else if(jumlahtemu == 1 && jumlahsirih == 2 && jumlahbroto == 1){
            _ramuan._ramuanHasil = "Ramuan Penglaris";
        }else if(jumlahsirih == 1 && jumlahbroto == 2 && jumlahkencur == 1){
            _ramuan._ramuanHasil = "Ramuan Kebal";
        }else if(jumlahbroto == 1 && jumlahkencur == 2 && jumlahtemu == 1){
            _ramuan._ramuanHasil = "Ramuan Waskita";
        }else if(jumlahkencur == 1 && jumlahbroto == 2 && jumlahtemu == 1){
            _ramuan._ramuanHasil = "Ramuan Santet";
        }else{
            _ramuan._ramuanHasil = "Ramuan Sampah aokweoakwko";
        }
    }    
}
