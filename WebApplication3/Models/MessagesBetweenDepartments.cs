using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Models
{
    public class MessagesBetweenDepartments
    {
        public int Id { get; set; }
        public string? TextMessage { get; set; }
        public DateTime Time { get; set; }
        public bool? Status { get; set; }


        [InverseProperty("MessagesBetweenDepartmentsSender")]
        public Employees? Sender { get; set; }
        [InverseProperty("MessagesBetweenDepartmentsRecipient")]
        public Employees? Recipient { get; set; }
    }
}
