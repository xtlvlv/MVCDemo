using UnityEngine;

namespace MyMVC
{
    public class RootUIController: MyController
    {
        private GameObject role;
        private RoleController _roleController; // 完整的MVC框架，可以把 controller注册到框架里，通过框架获得

        private RootUIView _rootUIView;
        #region 生命周期
        private void Awake()
        {
            _rootUIView = GetComponent<RootUIView>();
            if (_rootUIView==null)
            {
                Debug.LogError("未赋值");
            }
            
            role = GameObject.FindWithTag("Role");
            if (role==null)
            {
                Debug.LogError("玩家tag不存在");
            }

            _roleController = role.GetComponent<RoleController>();

            _rootUIView.NameInput.onValueChanged.AddListener((name) =>
            {
                _roleController.SetRoleName(name);
            });
            
            _rootUIView.DescInput.onValueChanged.AddListener((desc) =>
            {
                _roleController.SetRoleDesc(desc);
            });
            
            _rootUIView.NameUpdateBtn.onClick.AddListener(() =>
            {
                _roleController.SetRoleName(_rootUIView.NameInput.text);
                _roleController.UpdateName();
            });
        }

        #endregion
    }
}