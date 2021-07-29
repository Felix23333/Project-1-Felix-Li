using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
	GameObject[] floaters;
	public GameObject prefab;
	public GameObject parent;
	public Vector3 start;
	public Vector3 end;
    // Start is called before the first frame update
    void Start()
    {
		floaters = new GameObject[512];
		for(int i = 0; i < 512; i++)
        {
			floaters[i] = Instantiate(prefab, Vector3.Lerp(start, end, i / 512.0f), Quaternion.identity);
			floaters[i].transform.parent = parent.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
		int numPartitions = 512;
		float[] aveMag = new float[numPartitions];
		float[] aveMag1 = new float[numPartitions];
		float[] aveMag2 = new float[numPartitions];
		float[] aveMag3 = new float[numPartitions];
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
		for(int j = 0; j < 512; j++)
        {
			floaters[j].transform.localScale = new Vector3(0.05f, aveMag[j] * 100, 0.05f);
		}
		
	}
}
