using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWebApi.Models
{
    //Sınıfımızın eşlendiği tablonun adı ve şeması belirtiliyor.
    [Table(name: "Customers", Schema = "dbo")]
    public class Customer
    {
        //Tablonun anahtar alanı belirtiliyor.
        //Identity özelliği verilerek otomatik artan bir değer oluşturuluyor.
        //Veritabanında istenilen alanın adı belirtiliyor.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "customer_id")]
        public int Id { get; set; }

        [Column(name: "customer_name")]
        public string Name { get; set; }

        [Column(name: "customer_address")]
        public string Address { get; set; }

        [Column(name: "customer_email")]
        public string Email { get; set; }
    }
}