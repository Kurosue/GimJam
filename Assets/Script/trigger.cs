using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool temulawak, kencur, brotowali, sirih;
    public int jumlahsirih, jumlahbroto, jumlahtemu, jumlahkencur;
    objdrag broto, temu, siri, kencu;
    public GameObject objekbroto, objektemu, objekkencur, objeksirih;
    void Awake() {
        broto = objekbroto.GetComponent<objdrag>();
        kencu = objekkencur.GetComponent<objdrag>();
        temu = objektemu.GetComponent<objdrag>();
        siri = objeksirih.GetComponent<objdrag>();
    }
    void FixedUpdate(){
        if (brotowali && broto.isdilepas){
            jumlahbroto += 1;
        }if (kencur && kencu.isdilepas){
            jumlahkencur += 1;
        }if (temulawak && temu.isdilepas){
            jumlahtemu += 1;
        }if (sirih && siri.isdilepas){
            jumlahsirih += 1;
        }

    }
    void OnTriggerStay2D(Collider2D collide) {
        if (collide.CompareTag("brotowali"))
        {
            brotowali = true;
        }
        else if (collide.CompareTag("kencur")){
            kencur = true;
        }
        else if (collide.CompareTag("temulawak")){
             temulawak = true;
        }else if (collide.CompareTag("sirih")){
            sirih = true;
        }

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
        }
    }
}
