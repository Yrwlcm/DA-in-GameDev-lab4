using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PerceptronSimulation : MonoBehaviour
{
	// Start is called before the first frame update
	public Renderer Renderer;
	public Material[] Materials;
	public Perceptron SimulatedPerceptron;
	private Dictionary<int, int> boolLogic = new();

	void Start()
	{
		Renderer = GetComponent<Renderer>();
		foreach (var logic in SimulatedPerceptron.ts)
		{
			boolLogic.TryAdd((int)logic.input.Sum(), (int)logic.output);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.CompareTag("BoolCube"))
		{
			return;
		}

		var output = boolLogic[ConvertColorToInt(Renderer.material.name) +
		                       ConvertColorToInt(other.gameObject.GetComponent<Renderer>().material.name)];
		Renderer.material = Materials[output];
		Destroy(other.gameObject);
	}

	private static int ConvertColorToInt(string color)
	{
		return color.Contains("White") ? 1 : 0;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
