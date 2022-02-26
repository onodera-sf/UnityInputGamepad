using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadInfo : MonoBehaviour
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

    // ゲームパッドの各情報を取得
    Builder.AppendLine($"deviceId:{gamepad.deviceId}");
    Builder.AppendLine($"name:{gamepad.name}");
    Builder.AppendLine($"displayName:{gamepad.displayName}");
    Builder.AppendLine($"shortDisplayName:{gamepad.shortDisplayName}");
    Builder.AppendLine($"path:{gamepad.path}");
    Builder.AppendLine($"layout:{gamepad.layout}");

    // 情報をテキストで表示
    TextObject.text = Builder.ToString();
  }
}
