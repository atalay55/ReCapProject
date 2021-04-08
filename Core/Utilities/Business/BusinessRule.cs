using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;

namespace Core.Business
{
    public class BusinessRule
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
