# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по СЕКРЕТНОЙ лабораторной работе #4 выполнил(а):
- Холстинин Егор Алексеевич
- РИ-220943
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Познакомиться с работой перцептрона.

## Задание 1
### В проекте Unity реализовать перцептрон, который умеет производить вычисления OR, AND, NAND, XOR. Дать комментарии о корректности работы.
Ход работы:
- Создал пустой проект на юнити. Добавил в него скрипт с обучением перцептрона.
- Создал пустой обьект, повесил на него скрипт с перцептроном. Создал для него таблицу истиности.

![image](https://github.com/Yrwlcm/DA-in-GameDev-lab4/assets/99079920/fc3e7ebc-c30f-46b5-9b2f-444f2e32b4fd)

- Пронаблюдал через консоль как он обучается настраивая веса.
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab4/assets/99079920/31447814-dd9d-4ba5-ac68-c678f73b6368)

- OR - находил нужные веса и обучался довольно быстро.
- AND - находил нужные веса и обучался спустя 6-7 итераций.
- NAND - находил нужные веса и обучался спустя 6-7 итераций.
- XOR - чем дольше обучался тем хуже становились веса и количество ошибок.

## Задание 2
### Построить графики зависимости количества эпох от ошибки  обучения. Указать от чего зависит необходимое количество эпох обучения.

- Пронаблюдал количество ошибок в зависимости от эпохи. Занес эти данные в таблицу и построил графики.
- Необходимое количество эпох обучения зависит от того насколько тяжело подобрать подходящие веса удовлетворяющие таблице истиности.
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab4/assets/99079920/3f7049ce-c746-4bb8-af4b-9bd5711dbbcf)


## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.

- Визуальную модель перцептрона я решил построить следующим образом:
	- Есть два кубика разного цвета символизирующие 1 и 0
	- При соприкосновении кубик сверху уничтожается а нижний перекрашивается в результат по таблице истиности
	- Таблицу истиности я наследую от таблицы передаваемой в перцептроны для обучения 

```C#
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

```
- Работа визуальной модели на примере OR
- До соприкосновения:
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab4/assets/99079920/231cef42-f840-43b3-90ee-3424a64233ac)
- После соприкосновения: 
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab4/assets/99079920/895a88bf-b7c5-4654-a3e8-17df6c17e954)


## Выводы

В ходе данной лабораторной работы я познакомился с понятием перцептрона. Пронаблюдал то, каким образом его можно обучить. И создал свою визуальную модель его работы.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
