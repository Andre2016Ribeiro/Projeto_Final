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
using System.Web.Providers.Entities;
using System.Security.Claims;
using Azure;


namespace BotanicaFrontEnd.MeusServicos
{
    
    public class MeuServicoAzure 
    {
        
       
        public MeuServicoAzure(IConfiguration config)
        {
            _config = config;

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





        public async Task<List<Desafio>> ReceberMensagemAsync(string name)
        {

            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueName);


            


            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 20);
            List<Desafio> fileList = new List<Desafio>();
            foreach (var blobItem in messages)
            {
                
                var a = blobItem.Body.ToString().Split();
                string c = a.Last();
                
               
                string b = name;

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

        public async Task<List<Desafio>> ReceberrMensagemAsync(string name)
        {


            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);






            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 20);
            List<Desafio> fileList = new List<Desafio>();
            foreach (var blobItem in messages)
            {
                var a = blobItem.Body.ToString().Split();
                string c = a.Last();


                string b = name;
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
        public async Task<List<BlobStorage>> GetAllBlobFiles()
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);

                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(_blobContainerName);
                CloudBlobDirectory dirb = container.GetDirectoryReference(_blobContainerName);


                BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(string.Empty,
                    true, BlobListingDetails.Metadata, 100, null, null, null);
                List<BlobStorage> fileList = new List<BlobStorage>();

                foreach (var blobItem in resultSegment.Results)
                {

                    var blob = (CloudBlob)blobItem;
                    fileList.Add(new BlobStorage()
                    {
                        FileName = blob.Name,
                        FileSize = Math.Round((blob.Properties.Length / 1024f) / 1024f, 2).ToString(),
                        Modified = DateTime.Parse(blob.Properties.LastModified.ToString()).ToLocalTime().ToString()
                    });
                }
                return fileList;
            }
            catch (Exception)
            {

                throw;
            }
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
