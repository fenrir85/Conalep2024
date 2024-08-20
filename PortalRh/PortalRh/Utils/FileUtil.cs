using Microsoft.JSInterop;

namespace PortalRh.Utils
{
    public static class FileUtil
    {
        public static ValueTask SaveAs(IJSRuntime js, string filename, byte[] data)
        {
            return js.InvokeVoidAsync("FileUtil.saveAsFile", filename, Convert.ToBase64String(data));
        }
    }
}
