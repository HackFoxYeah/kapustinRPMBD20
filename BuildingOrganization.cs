//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KapustinRPMBDPR2
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuildingOrganization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BuildingOrganization()
        {
            this.BuildingObjects = new HashSet<BuildingObject>();
        }
    
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuildingObject> BuildingObjects { get; set; }
    }
}