//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemMonitoring.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeedFertilizer
    {
        public int IDSeed { get; set; }
        public int IDFettilizaer { get; set; }
        public Nullable<decimal> Count { get; set; }
    
        public virtual Fertilizer Fertilizer { get; set; }
        public virtual Seed Seed { get; set; }
    }
}
