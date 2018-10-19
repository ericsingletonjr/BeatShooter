using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {

    public GameObject SampleVisualizerPrefab;
    public float MaxScale = 2f;
    private GameObject[] _sampleVisualizer = new GameObject[512];
    private int _spacing = 10;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 512; i++)
        {
            GameObject instance = Instantiate(SampleVisualizerPrefab);
            instance.transform.parent = transform;
            instance.name = "Sample Band" + i;
            _spacing += i;
            instance.transform.position = Vector3.right * i;
            _sampleVisualizer[i] = instance;
        }
	}

	void Update () {
		for(int i = 0; i < _sampleVisualizer.Length; i++ )
        {
            if(_sampleVisualizer != null)
            {
                _sampleVisualizer[i].transform.localScale = new Vector3(0.5f, (AudioPeer.Samples[i] * MaxScale), 10);
            }
        }
	}
}
