using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GPNuoto.Model
{
    public class ServiceValidationRule
    {
        static public object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                // This is what we want.
                return propertyValue;
            }
            else
            {
                // ValidationStep was RawProposedValue or ConvertedProposedValue
                // The argument is already what we want!
                return value;
            }
        }
    }

    public class NotEmptyValidationRule : ValidationRule
    {
       

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return ValidationResult.ValidResult;
            string stringValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(false, "Campo richiesto.");
            }
           
                else
                    return ValidationResult.ValidResult;
            //}else
            //    return new ValidationResult(false, "Campo richiesto.");
        }
    }

    public class CodiceFiscaleValidationRule : ValidationRule
    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(false, "Campo richiesto.");
            }

            else
                if (CodiceFiscale.ControlloFormaleOK(stringValue))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Codice fiscale non valido.");
        }
    }


    public class CodiceISTATValidationRule : ValidationRule
    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(false, "Campo richiesto.");
            }

            else
            {
                IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                if (dataservice.CheckForCodiceISTAT(stringValue))
                    return new ValidationResult(false, "Codice ISTAT esistente.");
                else
                    return ValidationResult.ValidResult;
                    
            }
        }
    }

    public class NotEmptyIntValidationRule : ValidationRule
    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int? iValue = ServiceValidationRule.GetBoundValue(value) as int?;

            if (iValue == null || iValue <= 0)
            {
                return new ValidationResult(false, "Campo richiesto.");
            }

            else
                return ValidationResult.ValidResult;
           
        }
    }

    public class NotEmptyDataValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            

            if (string.IsNullOrWhiteSpace((value ?? "").ToString()))
             {
                return new ValidationResult(false, "Campo richiesto.");
             }
            else
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt.Year > 1900)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Data non valida.");
            }
        }
    }
    public class KeyModalitaPagamentoValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (sValue == null || sValue == string.Empty)
            {
                return new ValidationResult(false, "Campo richiesto.");
            }
            else
            {
                
                if (sValue.Length != 1)
                {
                    return new ValidationResult(false, "Codice deve essere composto da un solo carattere univoco.");
                }
                else
                {
                    IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
                    if (!ds.IsModalitaPagamento(sValue))
                        return ValidationResult.ValidResult;
                    else
                    return new ValidationResult(false, "Codice già usato.");
                }
            }
        }

   }
    public class UserValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (sValue == null || sValue == string.Empty)
            {
                return new ValidationResult(false, "Campo richiesto.");
            }
            else
            {
                    IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
                    if (ds==null || !ds.IsUser(sValue))
                        return ValidationResult.ValidResult;
                    else
                        return new ValidationResult(false, "Utente già usato.");
                }
        }

    }

    public class TipoAttivitaValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sValue = ServiceValidationRule.GetBoundValue(value) as string;

            if (sValue == null || sValue == string.Empty)
            {
                return new ValidationResult(false, "Campo richiesto.");
            }
            else
            {
                IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
                if (ds == null || !ds.IsTipoAttivita(sValue))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Tipo attività già usato.");
            }
            
        }

    }
    public class CodiceContabileValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sValue = ServiceValidationRule.GetBoundValue(value) as string;
            bool bIsNew = ((SingoloCodiceContabileViewModel) ((System.Windows.Data.BindingExpression) value).ResolvedSource).IsNew;

            if (sValue == null || sValue == string.Empty)
            {
                return new ValidationResult(false, "Campo richiesto.");
            }
            else
            {
                    IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
                    if (bIsNew==false || !ds.IsCodiceContabile(sValue))
                        return ValidationResult.ValidResult;
                    else
                        return new ValidationResult(false, "Codice già usato.");
            }
        }

    }

}
