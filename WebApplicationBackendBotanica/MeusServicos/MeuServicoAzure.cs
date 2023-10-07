using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using WebApplicationBackendBotanica.Models;


using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Reflection.Metadata;

namespace WebApplicationBackendBotanica.MeusServicos
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
           
            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);

           
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
                    string c= a.Last();
                    
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
        
         public async Task<List<Desafio>> ReceberrMensagemAsync()
         {

             
            QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);



            
            

                QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 10);
                List<Desafio> fileList = new List<Desafio>();
                foreach (var blobItem in messages)
                {
                    var a = blobItem.Body.ToString().Split();
                    string c= a.Last();
                    
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
        public async Task DeleteMenssagemAsync(string id)
        {
            try
            {
                QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueName);
                QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 30);
                //var messagesToDelete = messages.Where(m => m.MessageId == id).ToList();
                
                foreach (var blobItem in messages)
                {
                    if (blobItem.MessageId.ToString() == id)
                    {
                        await queueClient.DeleteMessageAsync(blobItem.MessageId, blobItem.PopReceipt);
                    }
                }   
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteMenssagemAsync1(string id)
        {
            try
            {
                QueueClient queueClient = new QueueClient(_storageAccountConnectionString, _queueNameRespostas);
                QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 30);
                //var messagesToDelete = messages.Where(m => m.MessageId == id).ToList();
                
                foreach (var blobItem in messages)
                {
                    if (blobItem.MessageId.ToString() == id)
                    {
                        await queueClient.DeleteMessageAsync(blobItem.MessageId, blobItem.PopReceipt);
                    }
                    else { }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<partilha>> GetAllBlobFiles()
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
               
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(_blobContainerName);
                CloudBlobDirectory dirb = container.GetDirectoryReference(_blobContainerName);


                BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(string.Empty,
                    true, BlobListingDetails.Metadata, 100, null, null, null);
                List<partilha> fileList = new List<partilha>();

                foreach (var blobItem in resultSegment.Results)
                {
                    
                    var blob = (CloudBlob)blobItem;
                    fileList.Add(new partilha()
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
        public async Task UploadBlobFileAsync(IFormFile files)
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
        public async Task DeleteDocumentAsync(string blobName)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_blobContainerName);
                var blob = cloudBlobContainer.GetBlobReference(blobName);
                await blob.DeleteIfExistsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
