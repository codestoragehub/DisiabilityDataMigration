using System.Collections.Generic;
using System.Linq;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Factories
{
    public static class InvoiceBuilder
    {
        public static Invoice CreateInvoice()
        {
            return new Invoice();
        }

        public static Invoice WithItem(this Invoice invoice, string itemName, decimal unitAmount)
        {
            invoice.InvoiceItems ??= new List<InvoiceItem>();

            invoice.InvoiceItems.Add(new InvoiceItem
            {
                Quantity = 1,
                ItemName = itemName,
                UnitAmount = unitAmount,
                TotalAmount = unitAmount
            });

            invoice.TotalAmount = invoice.InvoiceItems.Sum(i => i.TotalAmount);

            return invoice;
        }

        public static Invoice WithApplication(this Invoice invoice, Application application)
        {
            invoice.Application = application;

            return invoice;
        }

        public static Invoice WithStripePaymentMethod(this Invoice invoice, string stripePaymentMethod)
        {
            invoice.StripePaymentMethod = stripePaymentMethod;

            return invoice;
        }

        public static Invoice WithStripeCustomerId(this Invoice invoice, string stripeCustomerId)
        {
            invoice.StripeCustomerId = stripeCustomerId;

            return invoice;
        }
    }
}

