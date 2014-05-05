using System.Configuration;
using PayPal.Platform.SDK;
using PayPal.Services.Private.AP;
using System;

namespace ClsLibBLL.Paypal
{
    public class ClsAdaptivePaymentBLL
    {
        private BaseAPIProfile LerAPIProfile()
        {
            BaseAPIProfile profile = new BaseAPIProfile();
            profile.APIProfileType = ProfileType.ThreeToken;
            profile.APIUsername = ConfigurationManager.AppSettings["API_USERNAME"];
            profile.APIPassword = ConfigurationManager.AppSettings["API_PASSWORD"];
            profile.APISignature = ConfigurationManager.AppSettings["API_SIGNATURE"];
            profile.Environment = ConfigurationManager.AppSettings["ENDPOINT-HOMOLOGACAO"];
            profile.RequestDataformat = ConfigurationManager.AppSettings["API_REQUESTFORMAT"];
            profile.ResponseDataformat = ConfigurationManager.AppSettings["API_RESPONSEFORMAT"];
            profile.ApplicationID = ConfigurationManager.AppSettings["APPLICATION-ID"];

            return profile;
        }

        public PayResponse Pagar(string emailPagante, string emailRecebedor, decimal valor)
        {
            AdapativePayments ap = new AdapativePayments();
            PayRequest pr = new PayRequest();

            pr.cancelUrl = "http://www.google.com.br";
            pr.returnUrl = "http://www.google.com.br";
            //pr.senderEmail = "platfo_1255077030_biz@gmail.com";
            pr.senderEmail = emailPagante;
            pr.actionType = "PAY";
            //pr.currencyCode = "USD";
            pr.currencyCode = "BRL";

            pr.requestEnvelope = new RequestEnvelope();
            //pr.requestEnvelope.errorLanguage = "en_US";
            pr.requestEnvelope.errorLanguage = "pt_BR";
            
            pr.receiverList = new Receiver[1];
            pr.receiverList[0] = new Receiver();
            pr.receiverList[0].amount = valor;
            pr.receiverList[0].email = emailRecebedor;
            //pr.receiverList[0].email = "platfo_1255612361_per@gmail.com";

            pr.clientDetails = new ClientDetailsType();
            pr.clientDetails.applicationId = "AppID";
            pr.clientDetails.deviceId = ConfigurationManager.AppSettings["deviceId"];
            pr.clientDetails.ipAddress = ConfigurationManager.AppSettings["ipAddress"];
            
            ap.APIProfile = LerAPIProfile();
            PayResponse PResponse = ap.pay(pr);

            return PResponse;
        }
    }
}