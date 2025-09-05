using System.Security.Cryptography;

namespace I_AM.Application.Utilities;

#pragma warning disable CS8618
#pragma warning disable SYSLIB0041
#pragma warning disable SYSLIB0023

internal sealed class Security
{
    private static readonly object padlock = new();
    private static Security _instance;
    private const int Iterations = 8888;
    private const int SaltSize = 77;
    private const int HashSize = 33;

    private Security() 
    { 
    }

    public static Security GetInstance()
    {
        lock (padlock)
        {
            if (_instance == null)
                _instance = new();
        }
        return _instance;
    }

    internal string HashPassword(string password)
    {
        //[LV] Genera un salt aleatorio
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

        //[LV] Deriva la clave utilizando PBKDF2
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        //[LV] Combina el salt y el hash en un solo array
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        //[LV] Convierte el array a una cadena base64 para almacenarlo
        string hashedPassword = Convert.ToBase64String(hashBytes);

        return hashedPassword;
    }

    internal bool VerifyPassword(string password, string hashedPassword)
    {
        //[LV] Convierte la cadena base64 almacenada de nuevo a un array de bytes
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);

        //[LV] Extrae el salt del array
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        //[LV] Deriva la clave utilizando PBKDF2 con el salt almacenado
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        //[LV] Compara los hash generados
        for (int i = 0; i < HashSize; i++)
            if (hashBytes[i + SaltSize] != hash[i])
                return false;

        return true;
    }
}