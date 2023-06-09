using Microsoft.AspNetCore.Mvc.ModelBinding;
using Practic.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Practic.Data.Models
{
    public class Compiler
    {
        [BindNever]
        public int Id { get; set; }
        [Display()]
        public List<CompilerDetail> compailerDetails { get; set; }
    }
}
