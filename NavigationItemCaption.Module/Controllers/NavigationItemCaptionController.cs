using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationItemCaption.Module.Controllers
{
    public class NavigationItemCaptionController : WindowController
    {
        private ShowNavigationItemController navigationController;
        protected override void OnFrameAssigned()
        {
            UnsubscribeFromEvents();
            base.OnFrameAssigned();
            navigationController =  Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null)
            {
                navigationController.NavigationItemCreated += NavigationController_NavigationItemCreated; ;
            }
        }

        private void NavigationController_NavigationItemCreated(object sender, NavigationItemCreatedEventArgs e)
        {
            ChoiceActionItem navigationItem = e.NavigationItem;
            if(navigationItem.Items != null && navigationItem.Items.Count > 0)
            {
                foreach (ChoiceActionItem item in navigationItem.Items)
                {
                    IModelObjectView viewNode = ((IModelNavigationItem)item.Model).View as IModelObjectView;
                    if (viewNode != null)
                    {
                        ITypeInfo objectTypeInfo = XafTypesInfo.Instance.FindTypeInfo(viewNode.ModelClass.Name);
                        var attr = objectTypeInfo.FindAttribute<NavigationItemCaptionAttribute>();
                        if (attr != null)
                        {
                            navigationItem.Caption = attr.Caption;
                            break;
                        }
                    }
                }
            }

            
        }

        private void UnsubscribeFromEvents()
        {
            if (navigationController != null)
            {
                navigationController.NavigationItemCreated -=
                    NavigationController_NavigationItemCreated;
                navigationController = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            UnsubscribeFromEvents();
            base.Dispose(disposing);
        }
    }
}
