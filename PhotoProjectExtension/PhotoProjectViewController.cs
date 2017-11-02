using System;
using Foundation;
using AppKit;
using PhotosUI;

namespace PhotoProjectExtension
{
    public partial class PhotoProjectViewController : NSViewController, IPHProjectExtensionController
    {

        public PhotoProjectViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void LoadView()
        {
            base.LoadView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Do any additional setup after loading the view.
        }

        // This is not being called for some reason... what is this... PHProjectExtensionController_Extensions.GetSupportedProjectTypes(this);
        public PHProjectTypeDescription[] GetSupportedProjectTypes()
        {
            PHProjectTypeDescription desc = new PHProjectTypeDescription((NSString)"PHProjectTypeUndefined", "my title", "my desc", null);
    
            var types = new PHProjectTypeDescription[] { desc };
            // Fill the array with PHProjectTypeDescription instances representing you project types.
            // If you don't want to support custom project types set PHProjectExtensionDefinesProjectTypes to NO in the extension's Info.plist NSExtensionAttributes dictionary.
            return types;
        }

        public void BeginProject(PHProjectExtensionContext extensionContext, PHProjectInfo projectInfo, Action<NSError> completion)
        {
            InvokeOnMainThread(() =>
            {
                // do initialization here
                completion(null);
            });
        }

        public void ResumeProject(PHProjectExtensionContext extensionContext, Action<NSError> completion)
        {
            InvokeOnMainThread(() =>
            {
                // do initialization here
                completion(null);
            });
        }

        public void FinishProject(Action completion)
        {
            // do any finalization here
            completion();
        }

        public PHProjectExtensionContext GetProjectExtensionContext()
        {
            return (PHProjectExtensionContext)ExtensionContext;
        }
    }
}
