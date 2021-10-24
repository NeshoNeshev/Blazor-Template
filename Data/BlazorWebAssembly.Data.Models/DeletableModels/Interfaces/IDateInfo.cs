using System;

namespace BlazorWebAssembly.Data.Models.DeletableModels.Interfaces
{
    public interface IDateInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
