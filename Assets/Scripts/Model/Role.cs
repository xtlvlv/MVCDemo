using System;

namespace MyMVC
{
    public class Role : MyModel
    {
        private string name;        // 未使用数据驱动

        public BindData<string> Describe = new BindData<string>();  // 数据驱动, 为了方便，设置成公有
        public string Name
        {
            get { return name;}
            set 
            {
                
                name = value;
            }
        }

        public Role(string name)
        {
            Name = name;
        }
        // 注册Describe值变化处理事件
        public void RegistDescChangeEvent(Action<string> onDescChanged)
        {
            Describe.Register(onDescChanged);
        }
    }
}