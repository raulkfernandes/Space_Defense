using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.ObjectModel;
using System;

public class Ranking : MonoBehaviour {

    [SerializeField] private List<Colocado> listaDeColocados;
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    private string caminhoDoArquivo;

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        this.caminhoDoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        if(File.Exists(this.caminhoDoArquivo))
        {
            var textoJson = File.ReadAllText(this.caminhoDoArquivo);
            JsonUtility.FromJsonOverwrite(textoJson, this);
        }
        else
        {
            this.listaDeColocados = new List<Colocado>();
        }
    }

    public int AdicionarColocado(string nome, int pontos)
    {
        var id = this.listaDeColocados.Count * UnityEngine.Random.Range(1, 100000);

        var novoColocado = new Colocado(id, nome, pontos);
        this.listaDeColocados.Add(novoColocado);
        this.listaDeColocados.Sort();
        this.SalvarRanking();

        return id;
    }

    public void AlterarNome(int id, string novoNome)
    {
        foreach(var item in this.listaDeColocados)
        {
            if(item.id == id)
            {
                item.nome = novoNome;
                break;
            }
        }
        this.SalvarRanking();
    }

    public ReadOnlyCollection<Colocado> GetColocados()
    {
        return this.listaDeColocados.AsReadOnly();
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(this.caminhoDoArquivo, textoJson);
    }
}

[Serializable]
public class Colocado : IComparable
{
    public int id;
    public string nome;
    public int pontos;

    public Colocado(int id, string nome, int pontos)
    {
        this.id = id;
        this.nome = nome;
        this.pontos = pontos;
    }

    public int CompareTo(object obj)
    {
        var outroObjeto = obj as Colocado;
        return outroObjeto.pontos.CompareTo(this.pontos);
    }
}
