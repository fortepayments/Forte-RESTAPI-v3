using System.Collections.Generic;
using Newtonsoft.Json;


namespace Forte
{
    /// <summary>
    /// Provides operations for creating, finding, updating, and deleting Transactions in the vault
    /// </summary>
    public class ForteTransactionService
    {
        private string _strUser = "";
        private string _strPassword = "";
        private string _strAuthOrganizationId = "";
        private string _serverName = "";
        public string _url = "";

        public ForteTransactionService(ForteOptions createOptions)
        {
            createOptions.Resource = "transactions";
            _serverName = GetServerDetails.Geturl(createOptions);
            _strUser = createOptions.UserId;
            _strPassword = createOptions.Password;
            _strAuthOrganizationId = createOptions.AuthOrganizationId;
            var urlparam = ParameterBuilder.ApplyAllParameters(createOptions);
            _url = _serverName + urlparam;
        }

        public virtual IEnumerable<ForteTransaction> ListTransaction()
        {
            ForteException errTran = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "ListTransaction"
            };

            string response = Requestor.Get(_url, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errTran.ForteError.ErrorType = "#ERROR#";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errTran.ForteError.ErrorType = "NotFound";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errTran.ForteError.ErrorType = "BadRequest";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else
            {
                ForteListResult<ForteTransaction> forteResults = JsonConvert.DeserializeObject<ForteListResult<ForteTransaction>>(response);
                return forteResults.results;
            }
        }

        public string Create(ForteTransaction trans)
        {
            ForteException errTran = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "CreateTransaction"
            };
            var response = Requestor.PostString(_url, trans, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errTran.ForteError.ErrorType = "#ERROR#";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errTran.ForteError.ErrorType = "NotFound";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errTran.ForteError.ErrorType = "BadRequest";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else
            {
                return response;
            }
        }

        public ForteTransaction GetTransaction()
        {
            ForteTransaction forteTransaction = new ForteTransaction();
            ForteException errTran = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "GetTransaction"
            };
            string strtranResult = Requestor.Get(_url, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(strtranResult.IndexOf("#ERROR#") == -1))
            {
                errTran.ForteError.ErrorType = "#ERROR#";
                errTran.ForteError.Message = strtranResult;
                throw errTran;
            }
            else if (!(strtranResult.IndexOf("NotFound") == -1))
            {
                errTran.ForteError.ErrorType = "NotFound";
                errTran.ForteError.Message = strtranResult;
                throw errTran;
            }
            else if (!(strtranResult.IndexOf("BadRequest") == -1))
            {
                errTran.ForteError.ErrorType = "BadRequest";
                errTran.ForteError.Message = strtranResult;
                throw errTran;
            }
            else
            {
                forteTransaction = Mapper<ForteTransaction>.MapFromJson(strtranResult);
                return forteTransaction;
            }

        }

        public object Delete()
        {
            ForteException errTran = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "DeleteTransaction"
            };
            var response = Requestor.Delete(_url, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errTran.ForteError.ErrorType = "#ERROR#";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errTran.ForteError.ErrorType = "NotFound";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errTran.ForteError.ErrorType = "BadRequest";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else
            {
                return response;
            }
        }

        public object Update(ForteTransaction forteTran)
        {
            ForteException errTran = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "UpdateTransaction"
            };
            var response = Requestor.PutString(_url, forteTran, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errTran.ForteError.ErrorType = "#ERROR#";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errTran.ForteError.ErrorType = "NotFound";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errTran.ForteError.ErrorType = "BadRequest";
                errTran.ForteError.Message = response;
                throw errTran;
            }
            else
            {
                return response;
            }
        }
    }
}
