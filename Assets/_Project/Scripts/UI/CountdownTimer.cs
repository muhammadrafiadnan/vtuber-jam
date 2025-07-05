using UnityEngine;
using TMPro;

namespace Echoes
{
    public class CountdownTimer : MonoBehaviour
    {
        public float waktu; //Dalam detik
        public TextMeshProUGUI teksWaktu;

        void Update()
        {
            if (waktu > 0f)
            {
                waktu -= Time.deltaTime;
                if (waktu <= 0f) waktu = 0f;
            }

            int menit = Mathf.FloorToInt(waktu / 60f);
            int detik = Mathf.FloorToInt(waktu % 60f);

            teksWaktu.text = string.Format("{0:00}:{1:00}", menit, detik);
        }
    }
}
