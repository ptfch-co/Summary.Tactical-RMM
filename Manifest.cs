using Core.Modules.Manifest;
using Summary.TacticalRMM;

[assembly: Feature(
    Id = TacticalRMM.Features.TacticalRMM,
    Name = TacticalRMM.Localize.SubjectOfTacticalRMM,
    Description =TacticalRMM.Localize.DescriptionOfTacticalRMM,
    Category = TacticalRMM.Public.Category,
    Dependencies = new[] { "Core.Workflows" }
)]