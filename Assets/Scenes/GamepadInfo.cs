using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadInfo : MonoBehaviour
{
  /// <summary>����\��������e�L�X�g�I�u�W�F�N�g�B</summary>
  [SerializeField] private Text TextObject;

  StringBuilder Builder = new StringBuilder();

  // �X�V�̓t���[�����Ƃ�1��Ăяo����܂�
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} �� null �ł��B");
      return;
    }

    // �P�ڂ̃Q�[���p�b�h�̏����擾
    var gamepad = Gamepad.current;
    if (gamepad == null)
    {
      Debug.Log("�Q�[���p�b�h������܂���B");
      TextObject.text = "";
      return;
    }

    Builder.Clear();

    // �Q�[���p�b�h�̊e�����擾
    Builder.AppendLine($"deviceId:{gamepad.deviceId}");
    Builder.AppendLine($"name:{gamepad.name}");
    Builder.AppendLine($"displayName:{gamepad.displayName}");
    Builder.AppendLine($"shortDisplayName:{gamepad.shortDisplayName}");
    Builder.AppendLine($"path:{gamepad.path}");
    Builder.AppendLine($"layout:{gamepad.layout}");

    // �����e�L�X�g�ŕ\��
    TextObject.text = Builder.ToString();
  }
}
