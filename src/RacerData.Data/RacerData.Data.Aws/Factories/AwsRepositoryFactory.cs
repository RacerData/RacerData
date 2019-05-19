using System;
using System.Runtime.CompilerServices;
using log4net;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.Data.Aws.Adapters;
using RacerData.Data.Aws.Internal;
using RacerData.Data.Aws.Models;
using RacerData.Data.Aws.Ports;

[assembly: InternalsVisibleToAttribute("RacerData.Data.TestApp")]

namespace RacerData.Data.Aws.Factories
{
    class AwsRepositoryFactory : IAwsRepositoryFactory
    {
        #region fields

        private readonly ILog _log = null;
        private readonly IConfiguration _configuration = null;
        private readonly IResultFactory<IAwsRepository> _resultFactory;

        #endregion

        #region ctor

        public AwsRepositoryFactory(
            ILog log,
            IConfiguration configuration,
            IResultFactory<IAwsRepository> resultFactory)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _resultFactory = resultFactory ?? throw new ArgumentNullException(nameof(resultFactory));
        }

        #endregion

        #region public

        public IAwsRepository GetAwsRepository(AwsRepositoryType bucketType)
        {
            IAwsBucketConfiguration bucketConfiguration = null;
            switch (bucketType)
            {
                case AwsRepositoryType.LapAverages:
                    {
                        bucketConfiguration = new AwsRacerDataBucketConfiguration()
                        {
                            Prefix = _configuration["aws:lapAverages"]
                        };

                        break;
                    }
                case AwsRepositoryType.LapTimes:
                    {
                        bucketConfiguration = new AwsRacerDataBucketConfiguration()
                        {
                            Prefix = _configuration["aws:lapTimes"]
                        };

                        break;
                    }
                case AwsRepositoryType.Setup:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:setup"]
                        };

                        break;
                    }
                case AwsRepositoryType.Patch:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:patch"]
                        };

                        break;
                    }
                case AwsRepositoryType.Logs:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:logs"]
                        };

                        break;
                    }
                case AwsRepositoryType.SharedThemes:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:sharedThemes"]
                        };

                        break;
                    }
                case AwsRepositoryType.SharedWorkspaces:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:sharedWorkspaces"]
                        };

                        break;
                    }
                case AwsRepositoryType.SharedViews:
                    {
                        bucketConfiguration = new AwsRacerDataWebBucketConfiguration()
                        {
                            Prefix = _configuration["aws:sharedViews"]
                        };

                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"Unrecognized AwsBucketType in AwsRepositoryFactory: {bucketType.ToString()}");
                    }
            }

            return GetAwsRepository(bucketConfiguration);

        }

        public IAwsRepository GetAwsRepository(IAwsBucketConfiguration configuration)
        {
            try
            {
                return new AwsRepository(new AwsBucket(_log, configuration), _resultFactory);
            }
            catch (Exception ex)
            {
                _log?.Error("Error in creating new AWS repository", ex);

                throw;
            }
        }

        #endregion
    }
}
