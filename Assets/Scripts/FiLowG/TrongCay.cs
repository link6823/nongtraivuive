using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrongCay : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject GieoHat;
    public GameObject NayMam;
    public GameObject TruongThanh;
    public GameObject HaiQua;
    public GameObject TomatoPrefab;
    public Transform Player;

    private float countdownTime = 180f;
    private int minutes;
    private int seconds;

    void Start()
    {
        countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GieoHat.activeSelf && !countdownText.gameObject.activeSelf)
        {
            countdownText.gameObject.SetActive(true);
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            minutes = Mathf.FloorToInt(countdownTime / 60);
            seconds = Mathf.FloorToInt(countdownTime % 60);
            countdownText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);

            if (countdownTime <= 180f && countdownTime > 120f)
            {
                GieoHat.SetActive(true);
                NayMam.SetActive(false);
                TruongThanh.SetActive(false);
                HaiQua.SetActive(false);
            }
            else if (countdownTime <= 120f && countdownTime > 60f)
            {
                GieoHat.SetActive(false);
                NayMam.SetActive(true);
                TruongThanh.SetActive(false);
                HaiQua.SetActive(false);
            }
            else if (countdownTime <= 60f && countdownTime > 0f)
            {
                GieoHat.SetActive(false);
                NayMam.SetActive(false);
                TruongThanh.SetActive(true);
                HaiQua.SetActive(false);
            }

            countdownTime -= Time.deltaTime;
            yield return null;
        }

        countdownText.text = "00:00";
        GieoHat.SetActive(false);
        NayMam.SetActive(false);
        TruongThanh.SetActive(false);
        HaiQua.SetActive(true);
        countdownText.gameObject.SetActive(false);
    }

    public void ThuHoach()
    {
        GameObject tomato = Instantiate(TomatoPrefab, transform.position, Quaternion.identity);

        if (Player != null)
        {
            Vector3 direction = (Player.position - tomato.transform.position).normalized;
            float moveSpeed = 5f;
            StartCoroutine(MoveToPlayer(tomato, direction, moveSpeed));
        }

        HaiQua.SetActive(false);
        countdownText.text = "3:00";
    }

    IEnumerator MoveToPlayer(GameObject tomato, Vector3 direction, float speed)
    {
        while (tomato != null && Vector3.Distance(tomato.transform.position, Player.position) > 0.1f)
        {
            tomato.transform.position += direction * speed * Time.deltaTime;

            if (tomato == null)
            {
                yield break;
            }

            yield return null;
        }

        if (tomato != null)
        {
            tomato.transform.position = Player.position;
        }
    }
}
