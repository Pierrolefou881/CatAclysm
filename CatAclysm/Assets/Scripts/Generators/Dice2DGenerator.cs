using CatAclysm.Services;
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dice2DGenerator : MonoBehaviour
{
    [SerializeField] private int numberOfFaces = 6;
    [SerializeField] private int numberOfDices = 2;
    [SerializeField] private Sprite[] sprites = new Sprite[6];
    [SerializeField] private DiceService diceService;
    [SerializeField] private TMP_FontAsset diceFont;

    private void Start()
    {
        Generate(numberOfFaces, numberOfDices);
    }

    public GameObject Generate(int numberOfFaces, int numberOfDices = 1)
    {
        GameObject diceHolder = new($"DiceHolder");
        for (int i = 0; i < numberOfDices; i++)
        {
            GameObject newImageObject = new($"Dice{numberOfFaces}");

            Image newImage = newImageObject.AddComponent<Image>();

            newImage.color = Color.white;
            newImage.rectTransform.sizeDelta = new Vector2(250, 250);
            Vector3 pos = newImage.rectTransform.position;
            pos.x += (i * 275);
            newImage.rectTransform.position = pos;

            switch (numberOfFaces)
            {
                case 4:
                    newImage.sprite = sprites[0];
                    break;
                case 6:
                    newImage.sprite = sprites[1];
                    break;
                case 8:
                    newImage.sprite = sprites[2];
                    break;
                case 10:
                    newImage.sprite = sprites[3];
                    break;
                case 12:
                    newImage.sprite = sprites[4];
                    break;
                case 20:
                    newImage.sprite = sprites[5];
                    break;
                default:
                    Debug.LogError("Number of faces not supported. Supported values are 4, 6, 8, 10, 12, and 20.");
                    break;
            }

            AttachNumber(newImageObject.transform, numberOfFaces);

            newImageObject.transform.SetParent(diceHolder.transform);
        }

        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            diceHolder.transform.SetParent(canvas.transform, false);
        }
        else
        {
            Debug.LogError("Canvas not found. Please ensure you have a Canvas in your scene.");
        }

        return diceHolder;
    }

    private void AttachNumber(Transform parent, int numberOfFaces)
    {
        GameObject diceNumberObject = new($"DiceNumber (TMP)");

        TextMeshProUGUI diceNumber = diceNumberObject.AddComponent<TextMeshProUGUI>();
        StartCoroutine(RollDiceAnimation(3.0f, diceNumber, numberOfFaces));
        diceNumber.text = diceService.Roll(numberOfFaces).ToString();
        diceNumber.alignment = TextAlignmentOptions.MidlineGeoAligned;
        diceNumber.font = diceFont;
        diceNumber.color = Color.white;

        diceNumber.rectTransform.SetParent(parent, false);
    }

    private IEnumerator RollDiceAnimation(float diceTimeAnim, TextMeshProUGUI diceNumber, int numberOfFaces)
    {
        diceTimeAnim += Time.time;
        while (Time.time <= diceTimeAnim)
        {
            diceNumber.text = diceService.Roll(numberOfFaces).ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
