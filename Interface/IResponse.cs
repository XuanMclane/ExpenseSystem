using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Interface
{
    public interface IResponse
    {
        string ErrorMessage { get; set; }
        bool IsSuccess { get; set; }
    }
}
