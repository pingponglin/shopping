//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace foodapi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.Collect = new HashSet<Collect>();
            this.footprint = new HashSet<footprint>();
            this.Goodkowei = new HashSet<Goodkowei>();
            this.Goodtypetwo = new HashSet<Goodtypetwo>();
            this.Order = new HashSet<Order>();
            this.Ordertuihuo = new HashSet<Ordertuihuo>();
            this.Param = new HashSet<Param>();
            this.Score = new HashSet<Score>();
            this.shopping = new HashSet<shopping>();
        }
    
        public int Goodid { get; set; }
        public string GoodName { get; set; }
        public string GoodfuName { get; set; }
        public Nullable<decimal> GoodPrice { get; set; }
        public Nullable<decimal> GoodPrcieper { get; set; }
        public Nullable<int> Goodnum { get; set; }
        public string Goodsales { get; set; }
        public Nullable<System.DateTime> GoodCreatedate { get; set; }
        public string GoodImage { get; set; }
        public string Goodstatus { get; set; }
        public string GoodImagefu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collect> Collect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<footprint> footprint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goodkowei> Goodkowei { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goodtypetwo> Goodtypetwo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordertuihuo> Ordertuihuo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Param> Param { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Score { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shopping> shopping { get; set; }
    }
}
