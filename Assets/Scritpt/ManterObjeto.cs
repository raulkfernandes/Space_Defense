using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManterObjeto : MonoBehaviour {

    private void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
