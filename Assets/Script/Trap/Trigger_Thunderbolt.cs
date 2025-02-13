using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Thunderbolt : MonoBehaviour
{

    public GameObject Thunderbolt;
    public GameObject ThunderboltPoint;
    SpriteRenderer Renderer;
    int Mask;
    bool Exist_Thunderbolt = false;

    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();

        Mask = 1 << LayerMask.NameToLayer("Player");
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 12f, Mask);

        if (hit.collider != null && Exist_Thunderbolt == false)
        {
            Renderer.color = Color.gray;

            GameObject thunderbolt = Instantiate(Thunderbolt, ThunderboltPoint.transform.position, Quaternion.identity);
            Exist_Thunderbolt = true;
            Destroy(thunderbolt, 3);
        }
    }
}
