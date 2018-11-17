using Newtonsoft.Json;

namespace Domain
{
    using Enumeration;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("map.person")]
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            candidatefolders = new HashSet<candidatefolder>();
            contracts = new HashSet<contract>();
            jobrequests = new HashSet<jobrequest>();
            mandates = new HashSet<Mandate>();
            mandates1 = new HashSet<Mandate>();
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
        [JsonIgnore]
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

        [JsonIgnore]
        public double notePerson { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [JsonIgnore]
        public Role roleT { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string candidateState { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string clientCategory { get; set; }

        [StringLength(255)]
        public string clientType { get; set; }

        [JsonIgnore]
        public double? latitude { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string logo { get; set; }

        [JsonIgnore]
        public double? longitude { get; set; }

        [StringLength(255)]
        public string nameSociety { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string availability { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string businessSector { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string cv { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string jobType { get; set; }

        [JsonIgnore]
        public float? moyenneSkill { get; set; }

        [JsonIgnore]
        public float? note { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string picture { get; set; }

        [JsonIgnore]
        public float? salary { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string seniority { get; set; }

        [JsonIgnore]
        public double? taux { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string workProfil { get; set; }

        [JsonIgnore]
        public int? inBox_id { get; set; }

        [JsonIgnore]
        public int? project_id { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<candidatefolder> candidatefolders { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contracts { get; set; }

        [JsonIgnore]
        public virtual inbox inbox { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<jobrequest> jobrequests { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mandate> mandates { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mandate> mandates1 { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes1 { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resourceskill> resourceskills { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }

        [JsonIgnore]
        public virtual project project { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests1 { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests2 { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dayoff> dayoffs { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<organizationalchart> organizationalcharts { get; set; }
    }
}
