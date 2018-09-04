using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoDeColisao : MonoBehaviour {

    [SerializeField]
    private UnityEvent aoBater;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "Inimigo" && collision.collider.tag == "Inimigo")
        {
            GameObject.Destroy(this.gameObject);
        }
        else if (this.gameObject.tag == "Inimigo" && collision.collider.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            this.aoBater.Invoke();
            GameObject.Destroy(this.gameObject);
        }
    }
}
