﻿using Minor.Dag39.GamesBackend.WebApi.Errors;

namespace Minor.Dag39.GamesBackend.WebApi.Errors
{
    internal class ErrorMessage
    {
        public ErrorTypes FoutType { get; set; }
        public string FoutMelding { get; set; }
        public string Oplossing { get; set; }

        public ErrorMessage(ErrorTypes foutType, string foutmelding, string oplossing = null)
        {
            FoutType = foutType;
            FoutMelding = foutmelding;
            Oplossing = oplossing;
        }
    }
}
