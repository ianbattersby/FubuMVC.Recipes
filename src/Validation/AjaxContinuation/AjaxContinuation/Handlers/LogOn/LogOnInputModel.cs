using FubuValidation;

namespace AjaxContinuation.Handlers.LogOn
{
    public class LogOnInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}