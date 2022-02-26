using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadDpad : MonoBehaviour
{
  /// <summary>情報を表示させるテキストオブジェクト。</summary>
  [SerializeField] private Text TextObject;

  StringBuilder Builder = new StringBuilder();

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

    Builder.Clear();

    // Dpad の押下情報を Vector2 として取得するパターン
    var value = gamepad.dpad.ReadValue();
    Builder.Append($"(x:{value.x}, y:{value.y})");

    // Dpad の各方向のボタンを押しているかどうかの判定
    if (gamepad.dpad.left.isPressed) Builder.Append(" left");
    if (gamepad.dpad.right.isPressed) Builder.Append(" right");
    if (gamepad.dpad.up.isPressed) Builder.Append(" up");
    if (gamepad.dpad.down.isPressed) Builder.Append(" down");

    // Dpad の情報をテキストで表示
    TextObject.text = Builder.ToString();
  }
}
