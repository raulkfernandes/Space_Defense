using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuacaoInimigo : MonoBehaviour {

    private Pontuacao pontuacao;

    public void AvisarQuePontuou ()
    {
        this.pontuacao.AdicionarPontos();
    }

    public void DefinirPontuacao(Pontuacao pontuacao)
    {
        this.pontuacao = pontuacao;
    }
}
