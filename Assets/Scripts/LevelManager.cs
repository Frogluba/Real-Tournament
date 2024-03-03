using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text waveText;

    public async  void AnnounceWawe()
    {
        waveText.text = "Wave start";
        await new WaitForSeconds(2f);
        waveText.text = " ";
    }
}
