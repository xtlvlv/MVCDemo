using TMPro;
using UnityEngine;

namespace MyMVC
{
    // MV
    public class RoleView : MyView
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descText;

        public void UpdateRoleInfo(string name, string desc)
        {
            nameText.text = name;
            descText.text = desc;
        }
        public void UpdateRoleName(string name)
        {
            nameText.text = name;
        }
        public void UpdateRoleDesc(string desc)
        {
            descText.text = desc;
        }
    }
}