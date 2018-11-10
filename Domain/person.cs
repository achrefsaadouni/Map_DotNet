namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.person")]
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            candidatefolders = new HashSet<candidatefolder>();
            contracts = new HashSet<contract>();
            jobrequests = new HashSet<jobrequest>();
            mandates = new HashSet<mandate>();
            mandates1 = new HashSet<mandate>();
            messages = new HashSet<message>();
            notes = new HashSet<note>();
            notes1 = new HashSet<note>();
            resourceskills = new HashSet<resourceskill>();
            requests = new HashSet<request>();
            tests = new HashSet<test>();
            requests1 = new HashSet<request>();
            projects = new HashSet<project>();
            requests2 = new HashSet<request>();
            dayoffs = new HashSet<dayoff>();
            organizationalcharts = new HashSet<organizationalchart>();
        }

        [Required]
        [StringLength(31)]
        public string role { get; set; }

        public int id { get; set; }

        public int archived { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        public double notePerson { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string roleT { get; set; }

        [StringLength(255)]
        public string candidateState { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string clientCategory { get; set; }

        [StringLength(255)]
        public string clientType { get; set; }

        public double? latitude { get; set; }

        [StringLength(255)]
        public string logo { get; set; }

        public double? longitude { get; set; }

        [StringLength(255)]
        public string nameSociety { get; set; }

        [StringLength(255)]
        public string availability { get; set; }

        [StringLength(255)]
        public string businessSector { get; set; }

        [StringLength(255)]
        public string cv { get; set; }

        [StringLength(255)]
        public string jobType { get; set; }

        public float? moyenneSkill { get; set; }

        public float? note { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        public float? salary { get; set; }

        [StringLength(255)]
        public string seniority { get; set; }

        public double? taux { get; set; }

        [StringLength(255)]
        public string workProfil { get; set; }

        public int? inBox_id { get; set; }

        public int? project_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<candidatefolder> candidatefolders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contracts { get; set; }

        public virtual inbox inbox { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<jobrequest> jobrequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resourceskill> resourceskills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dayoff> dayoffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<organizationalchart> organizationalcharts { get; set; }
    }
}
