using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Object Escena;
    string nombreEscena;
    private float timer = 5f;
    private void Start()
    {
        nombreEscena = Escena.name;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
