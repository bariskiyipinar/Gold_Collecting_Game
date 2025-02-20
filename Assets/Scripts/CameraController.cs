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
        // Mouse giriþini al
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mousePos = Vector2.Scale(mousePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));

        // Lerp ile yumuþak geçiþ saðla
        gecispos.x = Mathf.Lerp(gecispos.x, mousePos.x, 1f / yumusaklik);
        gecispos.y = Mathf.Lerp(gecispos.y, mousePos.y, 1f / yumusaklik);

        // Pozisyonu güncelle
        campos += gecispos;

        // Clamp iþlemi ile dikey hareketi sýnýrla
        campos.y = Mathf.Clamp(campos.y, minY, maxY);
        
        // Kamera dönüþü (yukarý/aþaðý)
        transform.localRotation = Quaternion.Euler(-campos.y, 0f, 0f);

      
        // Oyuncunun dönüþü (saða/sola)
        oyuncu.transform.localRotation = Quaternion.Euler(0f, campos.x, 0f);
    }
}

