using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Enum
{
    public static class CodeResponse
    {
        public static string GetCode(int result)
        {
            var code = result switch
            {
                0 => "0000",
                1 => "1111",
                2 => "1111",
                3 => "1111",
                4 => "1111",
                _ => "",
            };
            return code;
        }
    }
}
