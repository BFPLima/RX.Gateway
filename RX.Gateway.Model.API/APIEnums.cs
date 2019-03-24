using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace RX.Gateway.Model.API
{
    public enum EStatusResponse
    {
        Undefined = 0,
        Success = 1,
        Error = 2
    }
}


namespace RX.Gateway.Model.API.Response.AntiFraud.ClearSale
{

    public enum EOrderStatusResponse
    {
        [Description("Automatic Approval – the order was automatically approved according to the rules defined")]
        APA,
        [Description("Manual Approval – the order was manually approved by a risk analyst")]
        APM,

        [Description("Denied without prejudice – Order was denied with no indication of fraud. Usually due to impossibility of contact or invalid document")]
        RPM,

        [Description("Manual Analysis – the order was sent to a manual analysis queue")]
        AMA,

        [Description("Error – An error occurred during the integration. It is necessary to analyze the XML and resend after fixing it")]
        ERR,

        [Description("New Order – the order was imported successfully and was not yet classified")]
        NVO,

        [Description("Fraud Suspicion – the order was denied due to a suspicion of fraud, usually based on contact with the customer or behavior registered in the ClearSale database")]
        SUS,

        [Description("Customer asked for cancellation– the customer asked an analyst to cancel the purchase")]
        CAN,

        [Description("Confirmed Fraud – The order was analyzed and, following contact made, the credit card company confirmed fraud or the owner of the credit card denied awareness of the purchase")]
        FRD,

        [Description("Automatically Denied – the order was denied according to a pre-defined rule (not recommended)")]
        RPA,

        [Description("Denied by Policy – The order was denied due to a policy defined by ClearSale or the client")]
        RPP
    }

}


namespace RX.Gateway.Model.API.Request.Acquirer.Stone
{
    [DataContract]
    public enum CurrencyIsoEnum
    {

        /// <summary>
        /// Real
        /// </summary>
        [EnumMember]
        BRL = 986,

        /// <summary>
        /// Euro
        /// </summary>
        [EnumMember]
        EUR = 978,

        /// <summary>
        /// Dólar
        /// </summary>
        [EnumMember]
        USD = 840,

        /// <summary>
        /// Argentine peso
        /// </summary>
        [EnumMember]
        ARS = 032,

        /// <summary>
        /// Boliviano
        /// </summary>
        [EnumMember]
        BOB = 068,

        /// <summary>
        /// Chilean peso
        /// </summary>
        [EnumMember]
        CLP = 152,

        /// <summary>
        /// Colombian peso
        /// </summary>
        [EnumMember]
        COP = 170,

        /// <summary>
        /// Uruguayan peso
        /// </summary>
        [EnumMember]
        UYU = 858,

        /// <summary>
        /// Peso Mexicano
        /// </summary>
        [EnumMember]
        MXN = 484,

        /// <summary>
        /// Paraguayan guaraní
        /// </summary>
        [EnumMember]
        PYG = 600
    }


    [DataContract]
    public enum CreditCardBrandEnum
    {

        /// <summary>
        /// Visa
        /// </summary>
        [EnumMember]
        Visa = 1,

        /// <summary>
        /// MasterCard
        /// </summary>
        [EnumMember]
        Mastercard = 2,

        /// <summary>
        /// Hipercard
        /// </summary>
        [EnumMember]
        Hipercard = 3,

        /// <summary>
        /// Amex
        /// </summary>
        [EnumMember]
        Amex = 4,

        /// <summary>
        /// Diners
        /// </summary>
        [EnumMember]
        Diners = 5,

        /// <summary>
        /// Elo
        /// </summary>
        [EnumMember]
        Elo = 6,

        /// <summary>
        /// Aura
        /// </summary>
        [EnumMember]
        Aura = 7,

        /// <summary>
        /// Discover
        /// </summary>
        [EnumMember]
        Discover = 8,

        /// <summary>
        /// Casa Show
        /// </summary>
        [EnumMember]
        CasaShow = 9,

        /// <summary>
        /// Havan
        /// </summary>
        [EnumMember]
        Havan = 10,

        /// <summary>
        /// HugCard
        /// </summary>
        [EnumMember]
        HugCard = 11,

        /// <summary>
        /// AndarAki
        /// </summary>
        [EnumMember]
        AndarAki = 12,

        /// <summary>
        /// LearderCard
        /// </summary>
        [EnumMember]
        LeaderCard = 13
    }


    [DataContract]
    public enum FrequencyEnum
    {

        /// <summary>
        /// Semanal
        /// </summary>
        [EnumMember]
        Weekly = 1,

        /// <summary>
        /// Mensal
        /// </summary>
        [EnumMember]
        Monthly = 2,

        /// <summary>
        /// Anual
        /// </summary>
        [EnumMember]
        Yearly = 3,

        /// <summary>
        /// Diário
        /// </summary>
        [EnumMember]
        Daily = 4
    }

    [DataContract]
    public enum CreditCardOperationEnum
    {

        /// <summary>
        /// Somente autorizar
        /// </summary>
        [EnumMember]
        AuthOnly = 1,

        /// <summary>
        /// Autorizar e capturar
        /// </summary>
        [EnumMember]
        AuthAndCapture = 2,

        /// <summary>
        /// Autorizar e capturar com atraso
        /// </summary>
        [EnumMember]
        AuthAndCaptureWithDelay = 3,
    }

}

