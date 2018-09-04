using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoMenu : MonoBehaviour {

    private float tempoDeEsperaBotoes = 0.1f;
    private LerCena lerCena;

    private void Awake()
    {
        lerCena = this.GetComponent<LerCena>();
    }

    public void IniciarJogo(string cena)
    {
        StartCoroutine(Iniciar(cena));
    }

    IEnumerator Iniciar(string cena)
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        lerCena.CarregarCena(cena);
    }

    public void SairDoJogo()
    {
        StartCoroutine(Sair());
    }

    IEnumerator Sair()
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
