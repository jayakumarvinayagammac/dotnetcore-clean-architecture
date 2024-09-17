using System.Windows.Input;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;

namespace ClassicModelApplication.Commands;

public record CreateOfficeCommand(OfficeDTO Office) : ICommand<OfficeCreationResult>;