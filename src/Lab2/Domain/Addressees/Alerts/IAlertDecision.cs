using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public interface IAlertDecision
{
    string? GetReason(Message message);
}