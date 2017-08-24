using Newtonsoft.Json.Linq;
using ReactNative.Bridge;
using ReactNative.Modules.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;

namespace uwpreactnativesample.MyModules
{
    class FilePickerModule : ReactContextNativeModuleBase
    {
        public FilePickerModule(ReactContext reactContext)
            : base(reactContext)
        {

        }

        public override string Name
        {
            get
            {
                return "FilePickerModule";
            }
        }

        [ReactMethod]
        public void openFile()
        {

            RunOnDispatcher(async () =>
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                openPicker.FileTypeFilter.Add(".jpg");
                openPicker.FileTypeFilter.Add(".jpeg");
                openPicker.FileTypeFilter.Add(".png");

                StorageFile file = await openPicker.PickSingleFileAsync().AsTask().ConfigureAwait(false);
                if (file != null)
                {
                    // Application now has read/write access to the picked file
                    System.Diagnostics.Debug.WriteLine("Picked photo: " + file.Name);
                    SendEvent("openFile", new JObject {
                        { "status", "Picked photo: " + file.Name }
                    });
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Operation cancelled.");
                    SendEvent("openFile", new JObject {
                        { "status", "Operation cancelled." }
                    });
                }
            });
        }

        private static async void RunOnDispatcher(DispatchedHandler action)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action).AsTask().ConfigureAwait(false);
        }

        private void SendEvent(string eventName, JObject parameters)
        {
            Context.GetJavaScriptModule<RCTDeviceEventEmitter>()
                .emit(eventName, parameters);
        }
    }
}
