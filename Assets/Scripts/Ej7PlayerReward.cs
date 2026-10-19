using UnityEngine;

public class Ej7PlayerReward : MonoBehaviour
{
    public float pointThreshold = 100f;
    public GameObject imageRewardPrefab;
    public RectTransform rewardPanelArea;
    public Ej6PuntosPlayer ej6PuntosPlayer;

    private float playerPoints;
    private int rewardCount;
    private float startY = -200f;

    void Start() {
        if (!imageRewardPrefab) {
            Debug.LogError(name + ": ¡No hay imagen de recompensa!");
        }
        if (!rewardPanelArea) {
            Debug.LogError(name + ": ¡No hay panel donde se pondrán las recompensas!");
        }
        if (!ej6PuntosPlayer) {
            Debug.LogError(name + ": ¡No hay script que controle los puntos del jugador!");
        }
        playerPoints = 0f;
        rewardCount = 0;
    }

    void Update() {
        playerPoints = ej6PuntosPlayer.GetComponent<Ej6PuntosPlayer>().GetPlayerPoints();
        float rewardedPoints = rewardCount * pointThreshold;
        if (playerPoints - rewardedPoints >= pointThreshold) {
            CreateNewReward();
        }
    }

    void CreateNewReward() {
        // Instanciamos la nueva imagen dentro del panel
        GameObject newReward = Instantiate(imageRewardPrefab, rewardPanelArea);
        // Obtenemos su RectTransform para moverla en píxeles de UI
        RectTransform rectTransform = newReward.GetComponent<RectTransform>();
        // Calculamos el desplazamiento
        float offsetX = 0f;
        float offsetY = rewardCount * 50f;
        // Asignamos la posición anclada relativa al panel
        rectTransform.anchoredPosition = new Vector2(offsetX, startY + offsetY);
        // Aumentar contador recompensas
        ++rewardCount;
    }
}
