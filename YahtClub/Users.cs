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
    
    public partial class Users
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public bool is_banned { get; set; }
        public Nullable<System.DateTime> last_entry { get; set; }
        public Nullable<System.DateTime> date_pass_change { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}
