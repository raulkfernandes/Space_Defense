using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDePause : MonoBehaviour {

    [SerializeField] private GameObject painelDePause;
    [SerializeField, Range(0, 1)] private float escalaDeTempoPause;
    private bool jogoEstaPausado;

    private void Update()
    {
        if(ChecarToqueNaTela())
        {
            if(jogoEstaPausado)
            {
                ContinuarJogo();
            }
        }
        else
        {
            if (!jogoEstaPausado)
            {
                PausarJogo();
            }
        }
    }

    private void ContinuarJogo ()
    {
        StartCoroutine(EsperarParaContinuar());
    }

    private IEnumerator EsperarParaContinuar ()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        MudarEscalaDeTempo(1);
        this.painelDePause.SetActive(false);
        this.jogoEstaPausado = false;
    }

    private void PausarJogo ()
    {
        this.painelDePause.SetActive(true);
        MudarEscalaDeTempo(this.escalaDeTempoPause);
        this.jogoEstaPausado = true;
    }

    private bool ChecarToqueNaTela ()
    {
        return Input.touchCount > 0;
    }

    private void MudarEscalaDeTempo (float escalaDeTempo)
    {
        Time.timeScale = escalaDeTempo;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
