using UnityEngine;

public class Ej5PuntosPlayer : MonoBehaviour
{
    private float points;
    private float shieldTipo1Value;
    private float shieldTipo2Value;

    void Start() {
        shieldTipo1Value = 5f;
        shieldTipo2Value = 10f;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("EscudoTipo1")) {
            points += shieldTipo1Value;
            Debug.Log(name + " (jugador) ha sumado +" + shieldTipo1Value + " puntos. Tiene en total " + points + " puntos.");
        } else if (collision.gameObject.CompareTag("EscudoTipo2")) {
            points += shieldTipo2Value;
            Debug.Log(name + " (jugador) ha sumado +" + shieldTipo2Value + " puntos. Tiene en total " + points + " puntos.");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("EscudoTipo1")) {
            points += shieldTipo1Value;
            Debug.Log(name + " (jugador) ha sumado +" + shieldTipo1Value + " puntos. Tiene en total " + points + " puntos.");
        } else if (collider.gameObject.CompareTag("EscudoTipo2")) {
            points += shieldTipo2Value;
            Debug.Log(name + " (jugador) ha sumado +" + shieldTipo2Value + " puntos. Tiene en total " + points + " puntos.");
        }
    }
}
