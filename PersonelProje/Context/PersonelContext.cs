using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web.DynamicData;

namespace PersonelProje.Context
{
    //1- Enable Migration
    //2-Add-Migration isim
    //3-Update-Database
    //Gerekirse 2 adýma git.
    public class PersonelContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        // Your context has been configured to use a 'PersonelContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PersonelProje.Context.PersonelContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PersonelContext' 
        // connection string in the application configuration file.
        public PersonelContext()
            : base("name=Connection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Sehir>Sehir  { get; set; }

        public virtual DbSet<Personel> Personel { get; set; }

    }
    [TableName("Sehir")]
    public class Sehir
    {
        public Sehir()
        {
            Personeller = new HashSet<Personel>();
        }       
        public int SehirId { get; set; }
        public string SehirAd{ get; set; }
        public virtual  HashSet<Personel> Personeller { get; set; }
    }
    [TableName("Personel")]
    public class Personel
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int SehirId { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Cins { get; set; }

        [ForeignKey("SehirId")]
        public virtual Sehir Sehir { get; set; }



    }
}