namespace AjaxContinuation.Handlers.LogOn
{
    using FubuValidation;

    public class LogOnInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}