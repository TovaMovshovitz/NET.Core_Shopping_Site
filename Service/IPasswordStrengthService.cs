namespace Service
{
    public interface IPasswordStrengthService
    {
        int passwordScore(string password);
    }
}