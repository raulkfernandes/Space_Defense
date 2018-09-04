using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizarPontuacao : MonoBehaviour {

    [SerializeField] private TextoDinamico textoPontuacao;
    [SerializeField] private Ranking ranking;
    private Pontuacao pontuacao;
    private int id;

    private void Start()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();

        int totalDePontos = -1;
        if(this.pontuacao != null)
        {
            totalDePontos = this.pontuacao.Pontos;
        }

        this.textoPontuacao.AtualizarTexto(totalDePontos);
        this.id = this.ranking.AdicionarColocado("Nome", totalDePontos);
    }

    public void AlterarNome(string nome)
    {
        if (nome == "") { nome = "Nome"; } //Define um valor default para evitar nome vazio, caso o jogador não digite nada
        this.ranking.AlterarNome(this.id, nome);
    }
}
