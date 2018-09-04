using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelRanking : MonoBehaviour {

    [SerializeField] private Ranking ranking;
    [SerializeField] private GameObject prefabPainelColocado;
    private ItemRanking[] paineisFilhos;
    
    private void Start()
    {
        this.AtualizarRanking();
    }

    public void AtualizarRanking()
    {
        paineisFilhos = GameObject.FindObjectsOfType<ItemRanking>();
        foreach (var painel in paineisFilhos)
        {
            GameObject.Destroy(painel.gameObject);
        }

        var listaDeColocados = this.ranking.GetColocados();

        for (var i = 0; i < listaDeColocados.Count; i++)
        {
            if (i >= 5) { break; }
            var colocado = GameObject.Instantiate(this.prefabPainelColocado, this.transform);
            colocado.GetComponent<ItemRanking>().ConfigurarRanking(i + 1, listaDeColocados[i].nome, listaDeColocados[i].pontos);
        }
    }
}
