using System.ComponentModel.DataAnnotations;

namespace ASP_NET_MVC_PL.Models
{
    /// <summary>
    /// Represents a view model of the operation with the bank account.
    /// </summary>
    public class OperationDataViewModel
    {
        [Display(Name = "Номер счета")]
        [Required(ErrorMessage = "Укажите номер счета для выполнения операции.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Некорректный номер счета.")]
        public int AccountIdTo { get; set; }

        [Display(Name = "Номер счета отправителя")]
        [Required(ErrorMessage = "Укажите номер счета для выполнения операции.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Некорректный номер счета.")]
        public int AccountIdFrom { get; set; }

        [Display(Name = "Сумма")]
        [Required(ErrorMessage = "Укажите сумму для выполнения операции.")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Некорректная сумма.")]
        public decimal Amount { get; set; }

        [Display(Name = "Операция")]
        public string Operation { get; set; }
    }
}