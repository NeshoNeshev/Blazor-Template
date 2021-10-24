using BlazorWebAssembly.Data.Models.DeletableModels.Interfaces;
using System;

namespace BlazorWebAssembly.Data.Models.DeletableModels
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletable
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
