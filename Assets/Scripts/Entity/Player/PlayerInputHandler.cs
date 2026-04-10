using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Camera mainCam;

    private Player player;
    private bool isMouseMoving;
    private Vector2 mouseScreenPosition;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (!isMouseMoving) return;

        Vector3 worldPos = mainCam.ScreenToWorldPoint(
            new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCam.nearClipPlane));

        player.SetWorldPosition(worldPos);
        player.hand.right = (Vector2)(worldPos - player.transform.position);

        isMouseMoving = false;
    }

    public void OnLook(InputValue value)
    {
        mouseScreenPosition = value.Get<Vector2>();
        isMouseMoving = true;
    }

    public void OnFire(InputValue value)
    {
        if (!value.isPressed)
            player.ExecuteSkill();
    }
}
