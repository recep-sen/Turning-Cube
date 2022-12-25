using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Score : MonoBehaviour
{
    private int score = 0;
    private bool isHit = false;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private ColorPair[] colors;
    [SerializeField] private MeshRenderer cube;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitAudioClip;

    public void ButtonClick()
    {
        if(!isHit && (Mathf.Abs(Cube.Instance.transform.eulerAngles.x) + 5) % 90 <= 10)
        {
            StartCoroutine(AddScore());
        }
    }

    private IEnumerator AddScore()
    {
        isHit = true;
        score++;
        particle.Play();
        ColorPair randomColors = colors[Random.Range(0, colors.Length)];
        Camera.main.backgroundColor = randomColors.color1;
        cube.material.color = randomColors.color2;
        text.text = score.ToString();
        audioSource.PlayOneShot(hitAudioClip);
        yield return new WaitForSeconds(0.5f);
        isHit= false;
    }
}

[System.Serializable]
public class ColorPair
{
    public Color color1;
    public Color color2;
}