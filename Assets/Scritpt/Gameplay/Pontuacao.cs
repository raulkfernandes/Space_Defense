using System;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour {

    [SerializeField] private UnityEventsIntegerExample aoPontuar;

    // Propriedade da classe Pontuacao:
    public int Pontos { get; private set; }

    public void AdicionarPontos ()
    {
        this.Pontos++;
        this.aoPontuar.Invoke(this.Pontos);
    }
}


[Serializable]
public class UnityEventsIntegerExample : UnityEvent<int>
{

}
