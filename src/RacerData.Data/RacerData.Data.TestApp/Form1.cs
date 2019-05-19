using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.Data.Aws.Factories;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;
using RacerData.Data.TestApp.Logging;

namespace RacerData.Data.TestApp
{
    public partial class Form1 : Form
    {
        #region fields

        private ILog _log = null;

        #endregion

        #region ctor

        public Form1()
        {
            InitializeComponent();

            Logger.Setup();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);

            txtMessages.AppendText($"{message}: {ex.ToString()}");

            MessageBox.Show(this, ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void MessageHandler(string message)
        {
            _log.Info(message);

            txtMessages.AppendText($"{DateTime.Now.ToString()}: {message}\r\n");
        }

        protected virtual void UpdateFormState()
        {
            //btnGetS3Objects.Enabled = (!String.IsNullOrEmpty(cboRepositories.Text));
            //btnGetS3Object.Enabled = (lstS3Objects.SelectedItem != null);
        }

        protected virtual void ClearS3ObjectDetails()
        {
            txtS3ObjectKey.Clear();
            txtS3Object.Clear();
            txtS3ObjectContentType.Clear();
            txtS3ObjectContentLength.Clear();
            txtS3ObjectETag.Clear();
        }

        protected virtual void DisplayS3ObjectDetails(IAwsItem s3Object)
        {
            txtS3Object.Text = s3Object.Content;
            txtS3ObjectKey.Text = s3Object.Key;
            txtS3ObjectContentType.Text = s3Object.ContentType;
            txtS3ObjectContentLength.Text = s3Object.ContentLength.ToString();
            txtS3ObjectETag.Text = s3Object.ETag;
        }

        protected virtual IAwsRepository GetRepository(AwsRepositoryType repositoryType)
        {
            var log = ServiceProvider.Instance.GetRequiredService<ILog>();
            var configuration = ServiceProvider.Instance.GetRequiredService<IConfiguration>();
            var resultFactory = ServiceProvider.Instance.GetRequiredService<IResultFactory<IAwsRepository>>();
            var factory = new AwsRepositoryFactory(log, configuration, resultFactory);

            var repository = factory.GetAwsRepository(repositoryType);

            return repository;
        }

        protected virtual AwsRepositoryType GetSelectedRepositoryType()
        {
            AwsRepositoryType repositoryType;
            var selected = cboRepositories.SelectedValue.ToString();

            if (Enum.TryParse(selected, out repositoryType))
                return repositoryType;
            else
                throw new ArgumentException($"Could not parse AwsRepositoryType from '{selected}'");
        }

        protected virtual IAwsItem GetSelectedItem()
        {
            IAwsItem selected = null;

            if (lstS3Objects.SelectedItem == null)
                MessageBox.Show("No key selected");
            else
            {
                selected = (IAwsItem)lstS3Objects.SelectedItem;

                if (selected != null)
                    return selected;
                else
                    MessageBox.Show("Empty item selected");
            }

            return selected;
        }

        protected virtual async Task GetAsync(AwsRepositoryType repositoryType, string key)
        {
            MessageHandler($"Begin GetAsync, item {repositoryType}:{key}");

            ClearS3ObjectDetails();

            var repository = GetRepository(repositoryType);

            var result = await repository.SelectAsync(key);

            if (result == null)
                throw new Exception("Null response from GetAsync");

            if (!result.IsSuccessful())
            {
                ExceptionHandler("GetAsync failed", result.Exception);
            }

            var s3Object = result.Value;

            DisplayS3ObjectDetails(s3Object);

            MessageHandler($"GetAsync finished. Returned item {s3Object.Key}.");
        }

        protected virtual async Task GetListAsync(AwsRepositoryType repositoryType)
        {
            MessageHandler($"Begin GetList {repositoryType}");

            var repository = GetRepository(repositoryType);

            var result = await repository.SelectListAsync();

            if (!result.IsSuccessful())
            {
                ExceptionHandler("GetListAsync failed", result.Exception);
            }

            var s3Objects = result.Value;

            lstS3Objects.DataSource = null;
            lstS3Objects.DisplayMember = "Key";
            lstS3Objects.DataSource = s3Objects.ToList();

            MessageHandler($"GetList finished. Returned {s3Objects.Count()} Items.");
        }

        protected virtual async Task PutAsync(AwsRepositoryType repositoryType, string key, string content)
        {
            MessageHandler($"Begin PutAsync, item {repositoryType}:{key}");

            var repository = GetRepository(repositoryType);

            IAwsItem item = new AwsItem()
            {
                Key = key,
                Content = content,
                ContentType = AwsContentType.Json
            };

            var result = await repository.PutAsync(item);

            if (!result.IsSuccessful())
            {
                ExceptionHandler("PutAsync failed", result.Exception);
            }

            var s3Object = result.Value;

            DisplayS3ObjectDetails(s3Object);

            MessageHandler($"PutAsync finished. Returned item {s3Object.Key}.");
        }

        protected virtual async Task DeleteAsync(AwsRepositoryType repositoryType, string key)
        {
            MessageHandler($"Begin DeleteAsync, item {repositoryType}:{key}");

            var repository = GetRepository(repositoryType);

            var result = await repository.DeleteAsync(key);

            if (!result.IsSuccessful())
            {
                ExceptionHandler("DeleteAsync failed", result.Exception);
            }

            MessageHandler($"DeleteAsync finished, no errors.");
        }

        #endregion

        #region private

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _log = ServiceProvider.Instance.GetRequiredService<ILog>();

                cboRepositories.DataSource = Enum.GetNames(typeof(AwsRepositoryType));

                UpdateFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading form", ex);
            }
        }

        private void cboRepositories_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating form state (Selected repository changed)", ex);
            }
        }

        private void lstS3Objects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error updating form state (Selected S3Object changed)", ex);
            }
        }

        private async void btnGetS3Objects_Click(object sender, EventArgs e)
        {
            try
            {
                var repositoryType = GetSelectedRepositoryType();

                await GetListAsync(repositoryType);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error getting list", ex);
            }
        }

        private async void btnGetS3Object_Click(object sender, EventArgs e)
        {
            try
            {
                var repositoryType = GetSelectedRepositoryType();

                var item = GetSelectedItem();

                await GetAsync(repositoryType, item.Key);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error getting item", ex);
            }
        }

        private async void btnPutS3Object_Click(object sender, EventArgs e)
        {
            try
            {
                var repositoryType = GetSelectedRepositoryType();

                var key = txtS3ObjectKey.Text.Trim();

                var content = txtS3Object.Text.Trim();

                await PutAsync(repositoryType, key, content);

                await GetAsync(repositoryType, key);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error putting item", ex);
            }
        }

        private async void btnDeleteS3Object_Click(object sender, EventArgs e)
        {
            try
            {
                var repositoryType = GetSelectedRepositoryType();

                var item = GetSelectedItem();

                if (item.Content == null || item.ContentType != AwsContentType.Json)
                {
                    MessageBox.Show("Can't remove a directory");
                    return;
                }

                var promptResult = MessageBox.Show(this, "Confirm Delete?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (promptResult != DialogResult.Yes)
                    return;

                await DeleteAsync(repositoryType, item.Key);

                await GetListAsync(repositoryType);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error deleting item", ex);
            }
        }

        #endregion
    }
}
