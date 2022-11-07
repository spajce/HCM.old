using System;

namespace HCM.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
    }
}
