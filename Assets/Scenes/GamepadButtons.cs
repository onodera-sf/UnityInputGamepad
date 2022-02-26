using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadButtons : MonoBehaviour
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

    // ボタンを押している間は xxxxxxxx.isPressed が true を返します

    // B ボタンや East ボタン、○ボタンは読み方が違うだけで同じボタンです
    // これは PlayStation や Xbox, Switch などでボタンの読み方が違うためです
    if (gamepad.aButton.isPressed) Builder.AppendLine($"A");
    if (gamepad.bButton.isPressed) Builder.AppendLine($"B");
    if (gamepad.xButton.isPressed) Builder.AppendLine($"X");
    if (gamepad.yButton.isPressed) Builder.AppendLine($"Y");

    if (gamepad.buttonEast.isPressed) Builder.AppendLine($"East");
    if (gamepad.buttonWest.isPressed) Builder.AppendLine($"West");
    if (gamepad.buttonNorth.isPressed) Builder.AppendLine($"North");
    if (gamepad.buttonSouth.isPressed) Builder.AppendLine($"South");

    if (gamepad.circleButton.isPressed) Builder.AppendLine($"Circle");
    if (gamepad.crossButton.isPressed) Builder.AppendLine($"Cross");
    if (gamepad.triangleButton.isPressed) Builder.AppendLine($"Triangle");
    if (gamepad.squareButton.isPressed) Builder.AppendLine($"Square");

    // コントローラーの中央にあるスタートボタン、セレクトボタン、メニューボタン、ビューボタンなどに該当します。
    if (gamepad.startButton.isPressed) Builder.AppendLine($"Start");
    if (gamepad.selectButton.isPressed) Builder.AppendLine($"Select");

    // 左と右のスティックをまっすぐ押し込んだかどうかを判定します
    if (gamepad.leftStickButton.isPressed) Builder.AppendLine($"LeftStickButton");
    if (gamepad.rightStickButton.isPressed) Builder.AppendLine($"RightStickButton");

    // 左上と右上にあるボタン。PlayStation だと L1 や R1 に該当します
    if (gamepad.leftShoulder.isPressed) Builder.AppendLine($"LeftShoulder");
    if (gamepad.rightShoulder.isPressed) Builder.AppendLine($"RightShoulder");

    // 押しているボタン一覧をテキストで表示
    TextObject.text = Builder.ToString();
  }
}
