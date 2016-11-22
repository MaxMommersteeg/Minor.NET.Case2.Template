using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.WebApi.Errors
{
    public enum ErrorTypes
    {
        Unknow = 0,
        DuplicateKey = 10,
        NotFound = 20,
        Unknown = 30,
        BadRequest = 40,
    }
}
