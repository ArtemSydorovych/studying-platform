namespace Common.Configurations.Exceptions;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string sectionName, Exception ex) : base($"Invalid configuration in section: {sectionName}", ex)
    {
    }
}