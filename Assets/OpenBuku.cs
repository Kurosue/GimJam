using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuku : MonoBehaviour
{
    [SerializeField] GameObject openBuku;

    public void Open()
    {
        openBuku.SetActive(true);
    }
    public void Close()
    {
        openBuku.SetActive(false);
    }
  
}
