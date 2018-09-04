using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueAlvo : MonoBehaviour {

    [SerializeField] private Transform alvo;
    [SerializeField] private float forcaAplicada;
    private Rigidbody2D fisica;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(this.alvo.gameObject.activeSelf == true)
        {
            var deslocamento = this.alvo.position - this.transform.position;
            deslocamento = deslocamento.normalized * this.forcaAplicada;

            this.fisica.AddForce(deslocamento, ForceMode2D.Force);
        }
    }

    public void DefinirAlvo(Transform alvo)
    {
        this.alvo = alvo;
    }
}
