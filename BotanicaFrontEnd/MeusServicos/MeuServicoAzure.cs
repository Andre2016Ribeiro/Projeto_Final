using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using BotanicaFrontEnd.Models;

namespace BotanicaFrontEnd.MeusServicos
{
    
    public class MeuServicoAzure
    {
        
        //Neste serviço, vou querer aceder ao ficheiro appsettings.json!
        //Por isso vou pedir à framework MVC Core que me injete o respetivo serviço (que existe sempre) para acesso a esse ficheiro:
        public MeuServicoAzure(IConfiguration config)
        {
            _config = config;

            // Get the name for the queue from appsettings
            _storageAccountConnectionString = _config["Azure:StorageAccountConnectionString"];
            _queueName = _config["Azure:QueueName"];
            _queueNameRespostas = _config["Azure:QueueNameRespostas"];
            _blobContainerName = _config["Azure:BlobContainerName"];
        }
        private readonly IConfiguration _config;
        private readonly string _storageAccountConnectionString;
        private readonly string _queueName;
        private readonly string _queueNameRespostas;
        private readonly string _blobContainerName;

        public void AcessoConfiguração()
        {
            
            string valor1 = _config["chave"];

            string valor2 = _config["Azure:chave"];
        }

        public async Task<string> EnviarMensagemAsync(string message)
        {
            
            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueName);

            
            await queueClient.CreateIfNotExistsAsync();

            
            SendReceipt receipt = await queueClient.SendMessageAsync(message);

            return receipt.MessageId;
        }

        

        public async Task<string> ReceberMensagemAsync()
        {
            
            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueName);
            


            if (queueClient.Exists())
            {
                
                QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 1);

                

                if (messages.Count() == 0 )
                    return "";
                else
                {
                    

                    return messages[0].Body.ToString();
                }
            }
            else
                
                return "";
        }
        #region OUTRA FORMA DE USAR MÉTODOS ASSÍNCRONOS NUM MÉTODO NÃO ASYNC:
        public async Task<string> ReceberrMensagemAsync()
        {
            
            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);

            // Create the queue
            if (queueClient.Exists())
            {
                QueueMessage[] resposta = await queueClient.ReceiveMessagesAsync(maxMessages: 1);

                //Se não foi recebida uma mensagem devolvemos "":
                if (resposta.Count() == 0)
                {
                    
                    return "";
                }
                else
                {
                  return  resposta[0].Body.ToString();
                     
                }
            }
            else
            {
                

                return "";
            }
        }
        #endregion

       

        public async Task UploadBlobAsync(IFormFile files)
        {
            try
            {
                byte[] dataFiles;

                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);

                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_blobContainerName);

                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                string systemFileName = files.FileName;
                await cloudBlobContainer.SetPermissionsAsync(permissions);
                await using (var target = new MemoryStream())
                {
                    files.CopyTo(target);
                    dataFiles = target.ToArray();
                }

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
                await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
