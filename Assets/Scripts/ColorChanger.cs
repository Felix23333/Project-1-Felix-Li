using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorChanger : MonoBehaviour
{
    int count = 0;
    bool bChange = true;
    public Color savedColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if(count == 10)
        {
            count = 0;
            UpdateColor();
        }
    }

    public void UpdateColor()
    {
        int numPartitions = 8;
        float[] aveMag = new float[numPartitions];
        float partitionIndx = 0;
        int numDisplayedBins = 512 / 2; //NOTE: we only display half the spectral data because the max displayable frequency is Nyquist (at half the num of bins)

        for (int i = 0; i < numDisplayedBins; i++)
        {
            if (i < numDisplayedBins * (partitionIndx + 1) / numPartitions)
            {
                aveMag[(int)partitionIndx] += AudioPeer.spectrumData[i] / (512 / numPartitions);
            }
            else
            {
                partitionIndx++;
                i--;
            }
        }

        if(bChange)
        {
            if (aveMag[0] * 100 < 1)
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
            }
            else if (aveMag[0] * 100 < 1.5)
            {
                GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1); ;
            }
            else if (aveMag[0] * 100 < 2)
            {
                GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1); ;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1); ;
            }
        }
        else
        {

        }
        
    }

    public void StopChangeColor()
    {
        bChange = false;
    }
    public void StartChangeColor()
    {
        bChange = true;
    }

    public void SaveColor()
    {
        savedColor = GetComponent<MeshRenderer>().material.color;
        PlayerPrefs.SetFloat("r", savedColor.r);
        PlayerPrefs.SetFloat("g", savedColor.g);
        PlayerPrefs.SetFloat("b", savedColor.b);
    }

    public void LoadColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"));
    }
}
