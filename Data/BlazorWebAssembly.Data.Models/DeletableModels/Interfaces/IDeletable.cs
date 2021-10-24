using System;

namespace BlazorWebAssembly.Data.Models.DeletableModels.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
