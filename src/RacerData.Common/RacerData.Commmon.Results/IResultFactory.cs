using System;
using RacerData.Common.Results;

namespace RacerData.Commmon.Results
{
    //public interface IResultFactory
    //{
    //    IResult Error(string message);
    //    IResult Exception(Exception ex);
    //    IResult Success();
    //}


    /// <summary>
    /// Factory for creating results.
    /// </summary>
    public interface IResultFactory
    {
        IResult Create();
       
        IResult Create(Exception ex);       
  
        IResult<TValue> Create<TValue>(TValue value);
      
        IResult<TValue> Create<TValue>(Exception ex);
    }
}