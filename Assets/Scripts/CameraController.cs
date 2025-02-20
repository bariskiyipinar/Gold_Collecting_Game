using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float hassasiyet = 5f;
    public float yumusaklik = 2f;
    public float minY = -45f;
    public float maxY = 45f;

    
    private   Vector2 campos;
    private  Vector2 gecispos;
    private GameObject oyuncu;

    void Start()
    {
        oyuncu = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse giri�ini al
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mousePos = Vector2.Scale(mousePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));

        // Lerp ile yumu�ak ge�i� sa�la
        gecispos.x = Mathf.Lerp(gecispos.x, mousePos.x, 1f / yumusaklik);
        gecispos.y = Mathf.Lerp(gecispos.y, mousePos.y, 1f / yumusaklik);

        // Pozisyonu g�ncelle
        campos += gecispos;

        // Clamp i�lemi ile dikey hareketi s�n�rla
        campos.y = Mathf.Clamp(campos.y, minY, maxY);
        
        // Kamera d�n��� (yukar�/a�a��)
        transform.localRotation = Quaternion.Euler(-campos.y, 0f, 0f);

      
        // Oyuncunun d�n��� (sa�a/sola)
        oyuncu.transform.localRotation = Quaternion.Euler(0f, campos.x, 0f);
    }
}

