﻿namespace CookingPot.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class CaptchaResponseViewModel
    {
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }

        [JsonProperty(PropertyName = "challenge_ts")]
        public DateTime ChallengeTime { get; set; }

        public string HostName { get; set; }

        public double Score { get; set; }

        public string Action { get; set; }
    }
}
