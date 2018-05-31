using System.ComponentModel.DataAnnotations;

namespace ASP_NET_MVC_PL.Models
{
    /// <summary>
    /// Represents a view model of the bank account.
    /// </summary>
    public class BankAccountViewModel
    {
        [Display(Name = "Номер счета")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя владельца счета.")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя владельца")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию владельца счета.")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия владельца")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Укажите количество средств для зачисления на счет.")]
        [Display(Name = "Сумма")]
        [DataType(DataType.Currency, ErrorMessage = "Поле для ввода суммы может иметь только числовое значение.")]
        public decimal Amount { get; set; }

        [Display(Name = "Бонусы")]
        public int Bonus { get; set; }

        [Display(Name = "Тип счета")]
        public string Type { get; set; }
    }
}