using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadReadValue : MonoBehaviour
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

    // トリガーの押下量を取得
    Builder.AppendLine($"LeftTrigger:{gamepad.leftTrigger.ReadValue()}");
    Builder.AppendLine($"RightTrigger:{gamepad.rightTrigger.ReadValue()}");

    // スティックの入力を取得
    var leftStickValue = gamepad.leftStick.ReadValue();
    Builder.AppendLine($"LeftStick:{leftStickValue.normalized * leftStickValue.magnitude}");
    var rightStickValue = gamepad.rightStick.ReadValue();
    Builder.AppendLine($"RightStick:{rightStickValue.normalized * rightStickValue.magnitude}");

    // 情報をテキストで表示
    TextObject.text = Builder.ToString();
  }
}
