using ClassicModelApplication.DataTransferObjects;
using ClassicModelCommon.Generics;

namespace ClassicModelApplication.Commands;

public record RemoveOfficeCommand(string OfficeCode) : ICommand<OfficeRemoveResult>;