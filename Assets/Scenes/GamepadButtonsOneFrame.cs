using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadButtonsOneFrame : MonoBehaviour
{
  /// <summary>情報を表示させるテキストオブジェクト。</summary>
  [SerializeField] private Text TextObject;

  // 更新はフレームごとに1回呼び出されます
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} が null です。");
      return;
    }

    // １つ目のゲームパッドの情報を取得
    var gamepad = Gamepad.current;
    if (gamepad == null)
    {
      Debug.Log("ゲームパッドがありません。");
      TextObject.text = "";
      return;
    }

    // ボタンが押された瞬間かどうかを判定
    if (gamepad.aButton.wasPressedThisFrame) TextObject.text += "A";
    if (gamepad.bButton.wasPressedThisFrame) TextObject.text += "B";
    if (gamepad.xButton.wasPressedThisFrame) TextObject.text += "X";
    if (gamepad.yButton.wasPressedThisFrame) TextObject.text += "Y";
  }
}
