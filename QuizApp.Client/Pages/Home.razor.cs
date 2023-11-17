using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuizApp.Client.Helper;

namespace QuizApp.Client.Pages
{
    public partial class Home
    {
        [Inject] IJSRuntime _JsRuntime { get; set; }
        private async Task test()
        {
            await _JsRuntime.ToastrSuccess("Success");
        }
    }
}
