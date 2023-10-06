using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using BotanicaFrontEnd.Models;
using BotanicaFrontEnd.Controllers;
using BotanicaFrontEnd.Data;
using BotanicaFrontEnd.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


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





        public async Task<List<Desafio>> ReceberMensagemAsync()
        {

            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueName);






            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 10);
            List<Desafio> fileList = new List<Desafio>();
            foreach (var blobItem in messages)
            {
                var a = blobItem.Body.ToString().Split();
                string c = a.Last();
                var foo = new user();
                
                string b = foo.gu().ToString();
                if (b == c)
                {
                    fileList.Add(new Desafio()
                    {

                        Contentor = _queueName,
                        Id = blobItem.MessageId,
                        Mensagem = blobItem.Body.ToString(),

                        Autor = c,

                        Modified = DateTime.Parse(blobItem.InsertedOn.ToString()).ToLocalTime().ToString()
                    });
                }
                else { }
                
            }
            return fileList;




        }

        public async Task<List<Desafio>> ReceberrMensagemAsync()
        {


            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);






            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 10);
            List<Desafio> fileList = new List<Desafio>();
            foreach (var blobItem in messages)
            {
                var a = blobItem.Body.ToString().Split();
                string c = a.Last();

                fileList.Add(new Desafio()
                {

                    Contentor = _queueName,
                    Id = blobItem.MessageId,
                    Mensagem = blobItem.Body.ToString(),

                    Autor = c,

                    Modified = DateTime.Parse(blobItem.InsertedOn.ToString()).ToLocalTime().ToString()
                });
            }
            return fileList;
        }


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
