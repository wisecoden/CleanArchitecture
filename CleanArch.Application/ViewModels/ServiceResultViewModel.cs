using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Application.ViewModels
{
    public class ServiceResultViewModel
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new();

        public static ServiceResultViewModel Ok() => new() { Success = true };
        public static ServiceResultViewModel Fail(params string[] errors) => new() { Success = false, Errors = errors.ToList() };
    }
}   