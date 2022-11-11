using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Reset the time scale because of pause screen in previous round
        Time.timeScale = 1;
    }
}
