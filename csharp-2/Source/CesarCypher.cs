using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {

        public int Chave { get; private set; }
        public CesarCypher()
        {
            Chave = 3;
        }
        public string Crypt(string message)
        {
                if (message is null)
                    throw new ArgumentNullException("Provided a null value for encrypting or decrypting.");
                else if (message.Length == 0)
                    return message;

                else
                {
                    int indice = 0;
                    string cifrado = "";
                    char[] cifradoVet = message.ToLower().ToCharArray();
                    int[] acumulador = new int[message.Length];
                    foreach (char x1 in cifradoVet)     //converte char para int
                    {
                        acumulador[indice] = (int)x1;
                        indice++;
                        if (x1 <= 31 || x1 >= 33)           // avaliação  !espaços
                            if (x1 <= 47 || x1 >= 58)       // avaliação !numero 
                                if (x1 <= 96 || x1 >= 123)  // avaliãção !caracter(a:z)
                                    throw new ArgumentOutOfRangeException("Value provided for encrypting or decrypting with special characters or accented letters.");

                    }
                    indice = 0;
                    foreach (int x1 in acumulador)
                    {
                        if (x1 >= 97 && x1 <= 122)
                        {
                            int temp = x1 + this.Chave;          //criptografa
                            if (temp >= 123 && temp <= 125) //caracter > z) 
                                temp -= 26;
                            cifradoVet[indice] = (char)temp;// inteiro em caractera 
                            cifrado += (char)temp;
                        }
                        else
                            cifrado += (char)x1;          //numeros e espaços para caracter
                    }
                    return cifrado;
                }
            }
            



        public string Decrypt(string cryptedMessage)
        {
           
                if (cryptedMessage is null)
                    throw new ArgumentNullException("Provided a null value for encrypting or decrypting.");
                else if (cryptedMessage.Length == 0)
                    return cryptedMessage;
                else
                {
                    int indice = 0;
                    string decifrado = "";
                    char[] cifradoVet = cryptedMessage.ToLower().ToCharArray(); //cria array com mensagem
                    int[] acumulador = new int[cryptedMessage.Length];
                    foreach (char x1 in cifradoVet)     //converte char para int
                    {
                        acumulador[indice] = (int)x1;
                        indice++;
                        if (x1 <= 31 || x1 >= 33)           // avaliação  !espaços
                            if (x1 <= 47 || x1 >= 58)       // avaliação !numero 
                                if (x1 <= 96 || x1 >= 123)  // avaliãção !caracter(a:z)
                                    throw new ArgumentOutOfRangeException("Value provided for encrypting or decrypting with special characters or accented letters.");
                    }
                    indice = 0;
                    foreach (int x1 in acumulador)
                    {
                        if (x1 >= 97 && x1 <= 122)
                        {
                            int temp = x1 - this.Chave;          //criptografa
                            if (temp <= 96) //caracter > z) 
                                temp += 26;
                            cifradoVet[indice] = (char)temp;// inteiro para caractera 
                            decifrado += (char)temp;
                        }
                        else
                            decifrado += (char)x1;          //numeros e espaços para caracter
                    }
                    return decifrado;
                }
            }
          
    }
}
