namespace Common.Configurations.Exceptions;

public class MissingConfigurationException : Exception
{
    public MissingConfigurationException(string bindingKey) : base($"Missing configuration for biding key: {bindingKey}")
    {
    }
}