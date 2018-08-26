using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj
{
    public abstract class Operation
    {
        //protected virtual void checkData() { }
        public abstract OperationResult execute(CimetEntities entities);
    }

    public class OperationResult
    {

        public bool Status { get; set; }
        public string Message { get; set; }

        public BaseDto[] Items { get; set; }

    }
}