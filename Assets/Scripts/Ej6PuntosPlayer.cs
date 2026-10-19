using System.Globalization;
using TMPro;
using UnityEngine;

public class Ej6PuntosPlayer : MonoBehaviour
{
    public bool destroyOnCollect = true;
    public TMP_Text pointsText;

    private float points = 0f;
    private const float shieldTipo1Value = 5f;
    private const float shieldTipo2Value = 10f;

    void Start() {
        if (!pointsText) {
            Debug.LogError(name + ": ¡No se ha seleccionado texto para mostrar la puntuación!");
        }
    }

    void Update() {
        pointsText.text = "Puntuación: " + points.ToString("F0", CultureInfo.InvariantCulture);
    }

    void OnCollisionEnter(Collision collision) {
        CheckAndProcessShield(collision.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        CheckAndProcessShield(other.gameObject);
    }

    void CheckAndProcessShield(GameObject hitObject) {
        float pointsToAdd = 0f;

        if (hitObject.CompareTag("EscudoTipo1")) {
            pointsToAdd = shieldTipo1Value;
        } 
        else if (hitObject.CompareTag("EscudoTipo2")) {
            pointsToAdd = shieldTipo2Value;
        }
        // Si el objeto chocado era un escudo válido, sumamos y destruimos opcionalmente
        if (pointsToAdd > 0f) {
            points += pointsToAdd;
            Debug.Log(name + " (jugador) ha sumado +" + pointsToAdd + " puntos. Tiene en total " + points + " puntos.");
            if (destroyOnCollect) {
                Destroy(hitObject);
            }
        }
    }

    public float GetPlayerPoints() {
        return points;
    }
}
