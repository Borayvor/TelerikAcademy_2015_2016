namespace UserVoiceSystem.Web.ViewModels.Account
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CaptchaResponseViewModel
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
