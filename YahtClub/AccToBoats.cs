//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YahtClub
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccToBoats
    {
        public int id { get; set; }
        public int accessory_id { get; set; }
        public int boat_id { get; set; }
    
        public virtual Accessory_id Accessory_id1 { get; set; }
        public virtual Boat Boat { get; set; }
    }
}