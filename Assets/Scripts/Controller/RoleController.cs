namespace MyMVC
{
    // C
    public class RoleController : MyController
    {
        private Role model;
        private RoleView view;

        #region 生命周期

        private void Awake()
        {
            model = new Role("Ming");
            view = gameObject.GetComponent<RoleView>(); // 类型不对会中断报错
            
            this.model.RegistDescChangeEvent((string desc) =>
            {
                model.Describe.Value = desc;
                updateDesc();
            });     // 当Describe 值发生变化，自动调用更新视图
        }

        private void Start()
        {
            updateView();
        }

        #endregion
 
        
        // 未使用数据驱动，需要自己调用 Set 设置值，并自己调用 updateView更新视图
        public void SetRoleName(string name)
        {
            model.Name = name;    
        }
        public string GetRoleName()
        {
            return model.Name;
        }
        
        // 使用数据驱动，值变化自动更新视图
        public void SetRoleDesc(string desc)
        {
            model.Describe.Value = desc;    
        }
        public string GetRoleDesc()
        {
            return model.Describe.Value;
        }
        
        // private void setRoleDesc(string desc){
        //     model.Describe.Value = desc;
        //     updateView();
        // }
 
        private void updateView()
        {
            view.UpdateRoleInfo(model.Name, model.Describe.Value);
        }
        public void UpdateName()
        {
            view.UpdateRoleName(model.Name);
        }  
        private void updateDesc()
        {
            view.UpdateRoleDesc(model.Describe.Value);
        }  
    }
}