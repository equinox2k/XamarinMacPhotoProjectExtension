using System;
using Foundation;
using AppKit;
using PhotosUI;
using System.Collections.Generic;

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

        [Export("supportedProjectTypes")]
        public PHProjectTypeDescription[] GetSupportedProjectTypes()
        {
            var result = new List<PHProjectTypeDescription>();
            InvokeOnMainThread(() =>
            {
                result.Add(new PHProjectTypeDescription(new NSString("PHProjectTypeUndefined"), "my title", "my desc", null));
                // Fill the array with PHProjectTypeDescription instances representing you project types.
                // If you don't want to support custom project types set PHProjectExtensionDefinesProjectTypes to NO in the extension's Info.plist NSExtensionAttributes dictionary.
            });
            return result.ToArray();
        }

        [Export("beginProjectWithExtensionContext:projectInfo:completion:")]
        public void BeginProject(PHProjectExtensionContext extensionContext, PHProjectInfo projectInfo, Action<NSError> completion)
        {
            InvokeOnMainThread(() =>
            {
                // do initialization here
                completion(null);
            });
        }

        [Export("resumeProjectWithExtensionContext:completion:")]
        public void ResumeProject(PHProjectExtensionContext extensionContext, Action<NSError> completion)
        {
            InvokeOnMainThread(() =>
            {
                // do resume here
                completion(null);
            });
        }

        [Export("finishProjectWithCompletionHandler:")]
        public void FinishProject(Action completion)
        {
            InvokeOnMainThread(() =>
            {
                // do finalization here
                completion();
            });
        }

        public PHProjectExtensionContext GetProjectExtensionContext()
        {
            return (PHProjectExtensionContext)ExtensionContext;
        }
    }
}
