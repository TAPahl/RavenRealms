using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    //  This script will be used for the credits links, have a invisible button over the text bringing
    //      players to the asset page and running OpenURL on clicked. 

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
