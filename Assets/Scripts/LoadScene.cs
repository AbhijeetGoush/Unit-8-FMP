using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public async void LoadScene2()
    {
        await Task.Delay(1000);
        SceneManager.LoadScene("Level2");
    }


}
