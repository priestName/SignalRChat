namespace SignalRChat.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLogs")]
    public partial class UserLogs
    {
        public int UserId { get; set; }
        
        public string Operate { get; set; }
        
        public string Message { get; set; }

        public DateTime AddTime { get; set; }
    }
}
