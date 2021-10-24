using BlazorWebAssembly.Data.Models.DeletableModels.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.Data.Models.DeletableModels
{
    public abstract class BaseModel<TKey> : IDateInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
