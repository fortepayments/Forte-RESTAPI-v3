using System.Collections.Generic;
using Newtonsoft.Json;

namespace Forte
{
    /// <summary>
    /// Provides operations for creating, finding, updating, and deleting Paymethods in the vault
    /// </summary>
    public class FortePaymethodsService
    {
        private string _strUser = "";
        private string _strPassword = "";
        private string _strAuthOrganizationId = "";
        private string _serverName = "";
        public string _url = "";

        public FortePaymethodsService(ForteOptions createOptions)
        {
            createOptions.Resource = "paymethods";
            _serverName = GetServerDetails.Geturl(createOptions);
            _strUser = createOptions.UserId;
            _strPassword = createOptions.Password;
            _strAuthOrganizationId = createOptions.AuthOrganizationId;
            var urlparam = ParameterBuilder.ApplyAllParameters(createOptions);
            _url = _serverName + urlparam;
        }

        public virtual string Create<T>(T paymethod)
        {
            ForteException errPay = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "CreatePaymethod"
            };
            var response = Requestor.PostString(_url, paymethod, _strUser, _strPassword, _strAuthOrganizationId);
            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errPay.ForteError.ErrorType = "#ERROR#";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errPay.ForteError.ErrorType = "NotFound";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errPay.ForteError.ErrorType = "BadRequest";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else
            {
                return response;
            }
        }
        public virtual FortePaymethod GetPaymethod()
        {
            FortePaymethod payResult = new FortePaymethod();
            ForteException errPay = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "GetPaymethod"
            };
            string strpayResult = Requestor.Get(_url, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(strpayResult.IndexOf("#ERROR#") == -1))
            {
                errPay.ForteError.ErrorType = "#ERROR#";
                errPay.ForteError.Message = strpayResult;
                throw errPay;
            }
            else if (!(strpayResult.IndexOf("NotFound") == -1))
            {
                errPay.ForteError.ErrorType = "NotFound";
                errPay.ForteError.Message = strpayResult;
                throw errPay;
            }
            else if (!(strpayResult.IndexOf("BadRequest") == -1))
            {
                errPay.ForteError.ErrorType = "BadRequest";
                errPay.ForteError.Message = strpayResult;
                throw errPay;
            }
            else
            {
                payResult = Mapper<FortePaymethod>.MapFromJson(strpayResult);
                return payResult;
            }

        }

        public virtual string Update<T>(T paymethod)
        {
            ForteException errPay = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "UpdatePaymethod"
            };
            var response = Requestor.PutString(_url, paymethod, _strUser, _strPassword, _strAuthOrganizationId);
            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errPay.ForteError.ErrorType = "#ERROR#";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errPay.ForteError.ErrorType = "NotFound";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errPay.ForteError.ErrorType = "BadRequest";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else
            {
                return response;
            }
        }

        public virtual string Delete()
        {
            ForteException errPay = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "DeletePaymethod"
            };
            var response = Requestor.Delete(_url, _strUser, _strPassword, _strAuthOrganizationId);
            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errPay.ForteError.ErrorType = "#ERROR#";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errPay.ForteError.ErrorType = "NotFound";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errPay.ForteError.ErrorType = "BadRequest";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else
            {
                return response;
            }
        }

        public virtual IEnumerable<FortePaymethod> ListPaymethod()
        {
            ForteException errPay = new ForteException()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Source = "ListPaymethod"
            };

            string response = Requestor.Get(_url, _strUser, _strPassword, _strAuthOrganizationId);

            if (!(response.IndexOf("#ERROR#") == -1))
            {
                errPay.ForteError.ErrorType = "#ERROR#";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("NotFound") == -1))
            {
                errPay.ForteError.ErrorType = "NotFound";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else if (!(response.IndexOf("BadRequest") == -1))
            {
                errPay.ForteError.ErrorType = "BadRequest";
                errPay.ForteError.Message = response;
                throw errPay;
            }
            else
            {
                ForteListResult<FortePaymethod> forteResults = JsonConvert.DeserializeObject<ForteListResult<FortePaymethod>>(response);
                return forteResults.results;
            }

        }

    }
}
