using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationItemCaption.Module.Controllers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NavigationItemCaptionAttribute : Attribute
    {
        private string caption;
        public NavigationItemCaptionAttribute(string caption)
        {
            this.caption = caption;
        }

        public virtual string Caption
        {
            get { return caption; }
        }
    }
}
