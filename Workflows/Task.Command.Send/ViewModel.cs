namespace Summary.TacticalRMM.Workflows.Task.Command.Send
{
    using System.ComponentModel.DataAnnotations;

    public class SendCommandInTacticalRMMViewModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Shell { get; set; }
        [Required]
        public string Agent { get; set; }
        [Required]
        public string Client { get; set; }

        [Required]
        public string Site { get; set; }
    }
}