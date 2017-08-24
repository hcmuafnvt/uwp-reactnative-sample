using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using ReactNative.UIManager.Events;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using XamlAnimatedGif;

namespace uwpreactnativesample.MyComponents
{
    public class ImageComponent : SimpleViewManager<Image>
    {
        public override string Name
        {
            get
            {
                return "ImageComponent";
            }
        }

        protected override Image CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Image();
        }

        [ReactProp("src")]
        public void SetSource(Image view, JObject src)
        {
            var uri = src.Value<string>("uri");
            AnimationBehavior.SetSourceUri(view, new Uri(uri));
        }
    }
}
