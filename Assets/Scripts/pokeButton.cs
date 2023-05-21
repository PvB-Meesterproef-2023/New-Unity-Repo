using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pokeButton : MonoBehaviour
{
    [SerializeField] Collider pokeColliderLeft;
    [SerializeField] Collider pokeColliderRight;

    public void OnTriggerEnter(Collider col)
    {
        if (col == pokeColliderLeft || col == pokeColliderRight)
        {
            gameObject.GetComponent<TextMeshPro>().text = "Reset";
        }
    }
}
