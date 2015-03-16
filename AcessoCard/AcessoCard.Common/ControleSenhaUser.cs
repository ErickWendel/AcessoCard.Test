using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AcessoCard.Common
{
    public class ControleSenhaUser
    {
        //nesse agoritmo, obrigatoriamente, as chaves devem ser de 16 bytes 
        private readonly byte[] _key = Encoding.Unicode.GetBytes("ErickWen");
        private readonly byte[] _segundaKey = Encoding.Unicode.GetBytes("GomesSil");

        public string CriptografarSenha(string senha)
        {
            var bytesDadosDesprotegidos = Encoding.Unicode.GetBytes(senha);
            using (var algoritmoRijndael = Aes.Create())
            {
                using (var criptografar = algoritmoRijndael.CreateEncryptor(_key, _segundaKey))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, criptografar, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesDadosDesprotegidos, 0, bytesDadosDesprotegidos.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] dadosSimetricamenteCriptografados = memoryStream.ToArray();
                    var senhaCriptografada = string.Join("-", dadosSimetricamenteCriptografados);
                    return senhaCriptografada;
                }
            }
        }

        public string Descriptografar(string senhaCriptografada)
        {
            var senhaAtual = senhaCriptografada.Split(new[] { '-' });
            var tamanhoArray = senhaAtual.Length;
            var dadosCriptografados = new byte[tamanhoArray];

            for (int i = 0; i < tamanhoArray; i++)
                dadosCriptografados[i] = Convert.ToByte(senhaAtual[i]);

            using (var algoritmoRijndael = Aes.Create())
            {
                using (var descriptografar = algoritmoRijndael.CreateDecryptor(_key, _segundaKey))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, descriptografar, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(dadosCriptografados, 0, dadosCriptografados.Length);
                    cryptoStream.FlushFinalBlock();

                    var dadosSimetricamenteDescriptografados = memoryStream.ToArray();
                    var senhaDescriptografada = Encoding.Unicode.GetString(dadosSimetricamenteDescriptografados);
                    return senhaDescriptografada;
                }
            }
        }


    }

}